using SetLibrary.Generic;
using SetLibrary.Objects_Sets;
using System;
using SetLibrary;
namespace Advanced_Sets
{
    public enum TypeOfAnimal
    {
        Dog,
        Cat,
        Horse
    }//TypeOfAnimal
    public class Animal : IObjectConverter<Animal>, IEquatable<Animal>, IComparable
    {
        public string Name { get; private set; }
        public TypeOfAnimal TypeOfAnimal { get; protected set; }
        public Animal()
        {

        }//ctor default
        public Animal(string name)
        {
            this.Name = name;
        }
        public int CompareTo(object obj)
        {
            return Name.CompareTo(((Animal)obj).Name);
        }//CompareTo

        public bool Equals(Animal other)
        {
            return this.TypeOfAnimal == other.TypeOfAnimal && this.Name == other.Name;
        }//Equals
        public virtual Animal ToObject(string field, SetExtractionSettings<Animal> settings)
        {
            string[] fields = field.Split(new string[] { settings.FieldTerminator }, StringSplitOptions.RemoveEmptyEntries);
            if (fields.Length != 3)
                throw new ArgumentException("Cannot make conversion");
            if(fields[0] == "Cat")
                return new Cat(fields[1], fields[2]);
            return new Dog(fields[1],fields[2]);
        }//ToObject
    }//class
    public class Cat : Animal
    {
        public string Color{ get; private set; }
        public Cat(string name, string color) : base(name)
        {
            TypeOfAnimal = TypeOfAnimal.Cat;
            Color = color;
        }
        public override string ToString()
        {
            return Color + " " + TypeOfAnimal+ " " + Name; //$"{Color} {TypeOfAnimal} Named {Name}";
        }//ToString
    }//namespace
    public class Dog : Animal
    {
        public string Breed { get; private set; }
        public Dog(string name, string breed) : base(name)
        {
            this.Breed = breed;
            base.TypeOfAnimal = TypeOfAnimal.Dog;
        }//ctor
        public override string ToString()
        {
            //For now
            return Breed + " " + TypeOfAnimal + " " +  Name;//$"{Breed} {TypeOfAnimal} Named {Name}";
        }//ToString
    }//class
}//namespace