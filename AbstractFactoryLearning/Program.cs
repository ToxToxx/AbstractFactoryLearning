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

            Chief butcher = new Chief(new ButcherFactory());
            butcher.GetNameOfMeal();
            butcher.Cook();


        }
    }

    abstract class Meal
    {
        public abstract void GiveNameOfMeal();
    }

    abstract class CookingProcess
    {
        public abstract void Cooking();
    }

    class BreadMeal : Meal
    { 
        public override void GiveNameOfMeal()
        {
            Console.WriteLine("You make bread");
        }
    }

    class MeatMeal : Meal
    {
        public override void GiveNameOfMeal()
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

    abstract class ChiefFactory
    {
        public abstract Meal CreateMeal();
        public abstract CookingProcess CreateCookingProcess();
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
    }

    class Chief
    {
        private Meal _meal;
        private CookingProcess _cookingProcess;

        public Chief( ChiefFactory chiefFactory )
        {
            
            _meal = chiefFactory.CreateMeal();
            _cookingProcess = chiefFactory.CreateCookingProcess();  
        }

        public void GetNameOfMeal()
        {
            _meal.GiveNameOfMeal();
        }

        public void Cook()
        {
            _cookingProcess.Cooking();
        }
    }
}
