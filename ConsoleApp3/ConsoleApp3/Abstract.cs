using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    abstract class Abstract
    {
        public abstract float GetArea();
        public abstract float GetPerimeter();
       
        public void PrintInfo()
        {
            Console.WriteLine($"Тип Фигуры {GetType().Name}");
            Console.WriteLine($"Площадь {GetArea()}") ;
            Console.WriteLine($"Периметр {GetPerimeter()}");
        }

    }
    class Circle : Abstract
    {
        private float _radius;

        public Circle(float radius)
        {
            _radius = radius;
        }

        public override float GetArea()
        {
            return Convert.ToSingle(Math.PI) * _radius * _radius;
        }
        public override float GetPerimeter()
        {
            return Convert.ToSingle(Math.PI) * _radius * 2;
        }
    }
    class Rectengel : Abstract
    {
        private float _height;
        private float _width;

        public Rectengel(float height, float width)
        {
            _height = height;
            _width = width;
        }

        public override float GetArea()
        {
            return _height * _width;
        }
        public override float GetPerimeter()
        {
            return _height * 2 + _width * 2;
        }
    }
    
    class Treygol : Abstract
    {
        private float _side1;
        private float _side2;
        private float _side3;


        public Treygol(float side1, float side2, float side3)
        {
            _side1 = side1;
            _side2 = side2;
            _side3 = side3;

        }

        public override float GetArea()
        {
            float p = GetPerimeter() / 2;
            return Convert.ToSingle(Math.Sqrt(p*(p - _side1) *(p - _side2) * (p- _side3)));
        }
        public override float GetPerimeter()
        {
            return _side1 + _side2 + _side3;
        }
    }
}
