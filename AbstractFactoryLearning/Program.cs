using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryLearning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Chief baker = new Chief(new BakerFactory());
            baker.GetNameOfMeal();
            baker.Cook();
            baker.GetPlaceOfWork();

            Console.WriteLine(new string ('-',25));

            Chief butcher = new Chief(new ButcherFactory());
            butcher.GetNameOfMeal();
            butcher.Cook();
            butcher.GetPlaceOfWork();


        }
    }

    abstract class Meal
    {
        public abstract void NameMeal();
    }

    abstract class CookingProcess
    {
        public abstract void Cooking();
    }

    abstract class PlaceOfWork
    {
        public abstract void NamePlace();
    }

    class BreadMeal : Meal
    { 
        public override void NameMeal()
        {
            Console.WriteLine("You make bread");
        }
    }

    class MeatMeal : Meal
    {
        public override void NameMeal()
        {
            Console.WriteLine("You make stake");
        }
    }

    class BakingProcess : CookingProcess
    {
        public override void Cooking()
        {
            Console.WriteLine("I am baking");
        }
    }

    class FryingProcess : CookingProcess
    {
        public override void Cooking()
        {
            Console.WriteLine("I am frying");
        }
    }

    class BakeryPlaceOfWork : PlaceOfWork
    {
        public override void NamePlace()
        {
            Console.WriteLine("I am working in bakery");
        }
    }
    
    class StakeHousePlaceOfWork : PlaceOfWork
    {
        public override void NamePlace()
        {
            Console.WriteLine("I am working in stakehouse");
        }
    }

    abstract class ChiefFactory
    {
        public abstract Meal CreateMeal();
        public abstract CookingProcess CreateCookingProcess();

        public abstract PlaceOfWork CreatePlaceOfWork();
    }



    class BakerFactory : ChiefFactory
    {
        public override Meal CreateMeal()
        {
            return new BreadMeal();

        }

        public override CookingProcess CreateCookingProcess()
        {
            return new BakingProcess();
        }

        public override PlaceOfWork CreatePlaceOfWork()
        {
            return new BakeryPlaceOfWork();
        }
    }

    class ButcherFactory : ChiefFactory
    {
        public override Meal CreateMeal()
        {
            return new MeatMeal();
        }

        public override CookingProcess CreateCookingProcess()
        {
            return new FryingProcess();
        }

        public override PlaceOfWork CreatePlaceOfWork()
        {
            return new StakeHousePlaceOfWork();
        }
    }

    class Chief
    {
        private Meal _meal;
        private CookingProcess _cookingProcess;
        private PlaceOfWork _placeOfWork;   

        public Chief( ChiefFactory chiefFactory )
        {
            
            _meal = chiefFactory.CreateMeal();
            _cookingProcess = chiefFactory.CreateCookingProcess();
            _placeOfWork = chiefFactory.CreatePlaceOfWork();
        }

        public void GetNameOfMeal()
        {
            _meal.NameMeal();
        }

        public void Cook()
        {
            _cookingProcess.Cooking();
        }

        public void GetPlaceOfWork()
        {
            _placeOfWork.NamePlace();
        }
    }
}
