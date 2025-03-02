using System;
using System.Collections.Generic;

//形状接口
public interface IShape
{
    double area { get; }
    bool isValid();
}

//形状抽象类，提供面积计算模板
public abstract class Shape : IShape
{
    public abstract double area { get; }
    public abstract bool isValid();
}

public class Rectangle : Shape
{
    public double length { get; set; }
    public double width { get; set; }

    public Rectangle(double _length, double _width)
    {
        this.length = _length;
        this.width = _width;
    }

    public override double area => length * width;
    public override bool isValid() => length > 0 && width > 0;
}

public class Square : Shape
{
    public double length { get; set; }

    public Square(double _length)
    {
        this.length = _length;
    }

    public override double area => length * length;
    public override bool isValid() => length > 0;
}

public class Triangle : Shape
{
    public double baseLength { get; set; }
    public double height { get; set; }

    public Triangle(double _baseLength, double _height)
    {
        this.baseLength = _baseLength;
        this.height = _height;
    }

    public override double area => baseLength * height * 0.5;
    public override bool isValid() => baseLength > 0 && height > 0;
}

public static class ShapeFactory
{
    public static IShape CreateShape(string shapeType, params double[] parameters)
    {
        switch (shapeType.ToLower())
        {
            case "rectangle":
                return new Rectangle(parameters[0], parameters[1]);
            case "square":
                return new Square(parameters[0]);
            case "triangle":
                return new Triangle(parameters[0], parameters[1]);
            default:
                throw new ArgumentException("Unknown shape type!");
        }
    }
}

public class Program
{
    public static void Main()
    {
        Random random = new Random();
        List<IShape> shapes = new();
        for (int i = 0; i < 10; i++)
        {
            string[] shapeTypes = { "rectangle", "square", "triangle" };
            string shapeType = shapeTypes[random.Next(0, shapeTypes.Length)];
            if (shapeType == "rectangle" || shapeType == "triangle")
            {
                shapes.Add(ShapeFactory.CreateShape(shapeType, random.Next(1, 10), random.Next(1, 10)));
            }
            else
            {
                shapes.Add(ShapeFactory.CreateShape(shapeType, random.Next(1, 10)));
            }
        }
        double totalArea = 0;
        foreach (var shape in shapes)
        {
            if (shape.isValid())
            {
                totalArea += shape.area;
                Console.WriteLine($"形状：{shape.GetType().Name}\t面积：{shape.area}");
            }
        }
        Console.WriteLine($"10个图形总面积：{totalArea}");
    }
}