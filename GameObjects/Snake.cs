﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_workshop.GameObjects
{
    public class Snake
    {
        private const char snakeSymbol = '\u25CF';
        private Queue<Point> SnakeElements;
        private readonly Food[] foods;
        private readonly Wall wall;
        private int foodIndex;
        public Snake(Wall wall)
        {
            this.wall = wall;
            this.foods = new Food[] { new FoodAsterisk(this.wall), new FoodDollar(this.wall), new FoodHash(this.wall) };

            this.CreateSnake();

        }

        public bool TryMove(Point point)
        {
            Point snakeHead = this.SnakeElements.Last();


            int nextLeftX = snakeHead.LeftX + point.LeftX;
            int nextTopY = snakeHead.TopY + point.TopY;

            bool isSnake = this.SnakeElements.Any(x => x.LeftX == nextLeftX && x.TopY == nextTopY);

            if (isSnake)
            {
                return false;
            }

            bool isWall = nextLeftX < 0 || nextTopY < 0 || nextLeftX >= this.wall.LeftX || nextTopY >= this.wall.TopY;

            if (isWall)
            {
                return false;
            }

            bool isFood = this.foods[foodIndex].LeftX == nextLeftX && this.foods[foodIndex].TopY == nextTopY;
            if (isFood)
            {
                this.Eat(nextLeftX, nextTopY);
            }
            Point snakePoint = new Point(nextLeftX, nextTopY);
            this.SnakeElements.Enqueue(snakePoint);
            snakePoint.Draw(snakeSymbol);

            Point lastPoint = this.SnakeElements.Dequeue();
            lastPoint.Draw(' ');
            return true;

            //get next point
            //check if snake

            //check if wall

            //check if food

            //move
        }

        private void Eat(int nextLeftX, int nextTopY)
        {
            Food food = this.foods[this.foodIndex];
            for (int i = 0; i < food.Points; i++)
            {
                this.SnakeElements.Enqueue(new Point(nextLeftX, nextTopY));
            }
            this.foodIndex = GetRandomIndex();
            this.foods[this.foodIndex].setRandomPosition(this.SnakeElements);
        }

        private void CreateSnake()
        {
            this.SnakeElements = new Queue<Point>();

            for (int i = 1; i <= 6; i++)
            {
                Point point = new Point(i, 1);
                SnakeElements.Enqueue(point);
                point.Draw(snakeSymbol);
            }
            this.foodIndex = GetRandomIndex();

            this.foods[foodIndex].setRandomPosition(this.SnakeElements);
        }
        private int GetRandomIndex() => new Random().Next(0, this.foods.Length);
            }
}
