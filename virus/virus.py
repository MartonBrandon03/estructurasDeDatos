#!/usr/bin/env python3

import random
import os
import sys
import time
from copy import deepcopy

GRID_SIZE = 15
EMPTY = '.'
PLAYER = 'P'
VIRUS = 'V'
BARRIER = '#'
EXIT = 'E'

def clear_screen():
    os.system('cls' if os.name == 'nt' else 'clear')

class LevelSpec:
    def __init__(self, level_num, virus_seeds=1, spread_prob=0.25, barrier_limit=25, steps_until_fast=0):
        self.level_num = level_num
        self.virus_seeds = virus_seeds
        self.spread_prob = spread_prob
        self.barrier_limit = barrier_limit
        self.steps_until_fast = steps_until_fast

class Game:
    def __init__(self):
        self.grid_size = GRID_SIZE
        self.levels = self._make_levels()
        self.level_index = 0
        self._setup_level()

    def _make_levels(self):
        return [
            LevelSpec(1, 1, 0.20, 25, 12),
            LevelSpec(2, 2, 0.22, 22, 10),
            LevelSpec(3, 2, 0.26, 20, 9),
            LevelSpec(4, 3, 0.30, 18, 8),
            LevelSpec(5, 3, 0.35, 16, 6),
        ]

    def _setup_level(self):
        self.level = deepcopy(self.levels[self.level_index])
        n = self.grid_size
        self.grid = [[EMPTY for _ in range(n)] for _ in range(n)]
        self.player_pos = (n // 2, 0)
        self.grid[self.player_pos[0]][self.player_pos[1]] = PLAYER
        exit_row = random.choice([r for r in range(n) if r != self.player_pos[0]])
        self.exit_pos = (exit_row, n - 1)
        self.grid[self.exit_pos[0]][self.exit_pos[1]] = EXIT
        self.virus_cells = set()
        center = n // 2
        while len(self.virus_cells) < self.level.virus_seeds:
            r = random.randint(center - 2, center + 2)
            c = random.randint(center - 2, center + 2)
            if (r, c) != self.player_pos and (r, c) != self.exit_pos:
                self.virus_cells.add((r, c))
        for (r, c) in self.virus_cells:
            self.grid[r][c] = VIRUS
        self.barriers_left = self.level.barrier_limit
        self.barriers = set()
        self.step_count = 0
        self.game_over = False
        self.win = False

    def display(self):
        clear_screen()
        print(f"-- Nivel {self.level.level_num} --")
        print(f"Turno: {self.step_count}   Barreras: {self.barriers_left}   Virus: {len(self.virus_cells)}")
        print('-' * (self.grid_size * 2 + 3))
        for r in range(self.grid_size):
            row = ' '.join(self.grid[r])
            print(f"{r:02d} | {row}")
        print('-' * (self.grid_size * 2 + 3))
        print('   ' + ' '.join(f"{c:02d}" for c in range(self.grid_size)))

    def in_bounds(self, r, c):
        return 0 <= r < self.grid_size and 0 <= c < self.grid_size

    def empty_at(self, r, c):
        return self.in_bounds(r, c) and self.grid[r][c] == EMPTY

    def adjacent(self, pos):
        r, c = pos
        for dr, dc in [(-1,0),(1,0),(0,-1),(0,1)]:
            yield (r+dr, c+dc)

    def player_move(self, dr, dc):
        if self.game_over: return
        r, c = self.player_pos
        nr, nc = r + dr, c + dc
        if not self.in_bounds(nr, nc):
            return
        if (nr, nc) in self.barriers:
            return
        if (nr, nc) in self.virus_cells:
            self.player_pos = (nr, nc)
            self.grid[r][c] = EMPTY
            self.grid[nr][nc] = PLAYER
            self.game_over = True
            self.win = False
            print("Infectado.")
            return
        self.grid[r][c] = EMPTY
        self.player_pos = (nr, nc)
        if (nr, nc) == self.exit_pos:
            self.grid[nr][nc] = PLAYER
            self.game_over = True
            self.win = True
            print("Ganaste.")
            return
        self.grid[nr][nc] = PLAYER

    def place_barrier(self, r, c):
        if not self.in_bounds(r, c): return
        if (r, c) == self.player_pos or (r, c) == self.exit_pos: return
        if self.grid[r][c] == BARRIER or self.grid[r][c] == VIRUS: return
        if self.barriers_left <= 0: return
        self.grid[r][c] = BARRIER
        self.barriers.add((r, c))
        self.barriers_left -= 1

    def remove_barrier(self, r, c):
        if not self.in_bounds(r, c): return
        if (r, c) not in self.barriers: return
        self.barriers.remove((r, c))
        self.grid[r][c] = EMPTY
        self.barriers_left += 1

    def move_barrier(self, r1, c1, r2, c2):
        if not self.in_bounds(r1, c1) or not self.in_bounds(r2, c2): return
        if (r1, c1) not in self.barriers: return
        if (r2, c2) == self.player_pos or (r2, c2) == self.exit_pos or (r2, c2) in self.virus_cells: return
        if self.grid[r2][c2] == BARRIER: return
        self.barriers.remove((r1, c1))
        self.grid[r1][c1] = EMPTY
        self.barriers.add((r2, c2))
        self.grid[r2][c2] = BARRIER

    def virus_step(self):
        new_virus = set()
        spread_prob = self.level.spread_prob
        if self.step_count >= self.level.steps_until_fast > 0:
            spread_prob = min(1.0, spread_prob + 0.12)
        for (r, c) in self.virus_cells:
            for nr, nc in self.adjacent((r, c)):
                if not self.in_bounds(nr, nc): continue
                if self.grid[nr][nc] == EMPTY and random.random() < spread_prob:
                    new_virus.add((nr, nc))
        for (r, c) in new_virus:
            self.grid[r][c] = VIRUS
        self.virus_cells |= new_virus
        if self.player_pos in self.virus_cells:
            self.game_over = True
            self.win = False
            print("Perdiste.")

    def check_enclosed(self):
        for cell in self.virus_cells:
            for nr, nc in self.adjacent(cell):
                if self.in_bounds(nr, nc) and self.grid[nr][nc] == EMPTY:
                    return False
        return True

    def next_level(self):
        self.level_index += 1
        if self.level_index >= len(self.levels):
            print("Ganaste todo.")
            self.game_over = True
            self.win = True
            return
        print("Siguiente nivel...")
        time.sleep(1.0)
        self._setup_level()

    def step(self, cmd_line):
        parts = cmd_line.strip().split()
        if not parts:
            return
        cmd = parts[0].lower()
        if cmd in ('w','a','s','d') and len(parts) == 1:
            mapping = {'w':(-1,0),'s':(1,0),'a':(0,-1),'d':(0,1)}
            dr, dc = mapping[cmd]
            self.player_move(dr, dc)
        elif cmd == 'place' and len(parts) == 3:
            r = int(parts[1]); c = int(parts[2])
            self.place_barrier(r, c)
        elif cmd == 'remove' and len(parts) == 3:
            r = int(parts[1]); c = int(parts[2])
            self.remove_barrier(r, c)
        elif cmd == 'movebar' and len(parts) == 5:
            r1 = int(parts[1]); c1 = int(parts[2]); r2 = int(parts[3]); c2 = int(parts[4])
            self.move_barrier(r1, c1, r2, c2)
        elif cmd == 'pass':
            pass
        elif cmd == 'quit':
            print('Saliendo...')
            sys.exit(0)
        if not self.game_over:
            self.step_count += 1
            self.virus_step()
            if not self.game_over and self.check_enclosed():
                self.game_over = True
                self.win = True
                print('Encerraste el virus.')

    def run(self):
        while True:
            self.display()
            if self.game_over:
                if self.win:
                    print('Nivel completado.')
                    self.next_level()
                    if self.game_over and self.win and self.level_index >= len(self.levels):
                        print('Fin del juego.')
                        break
                    continue
                else:
                    print('Reiniciar? (y/n)')
                    ans = input('> ').strip().lower()
                    if ans == 'y':
                        self._setup_level()
                        continue
                    else:
                        print('Fin.')
                        break
            cmd = input('> ')
            self.step(cmd)

if __name__ == '__main__':
    random.seed()
    game = Game()
    try:
        game.run()
    except KeyboardInterrupt:
        print('\nAdiós.')
