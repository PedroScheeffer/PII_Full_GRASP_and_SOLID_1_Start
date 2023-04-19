//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
            Console.WriteLine($"Costo producion total: {this.GetProductionCost()}");
        }
        // Utilizo expert porque en Recipe tengo la informacion necesaria para realizar la operacion: step, tambien
        // SRP Porque Recipe ya se encarga de los pasos de la produción 
        private double GetProductionCost(){
            double totalProductionCost = 0;
                foreach (Step step in steps)
                {
                    totalProductionCost = totalProductionCost + (step.Quantity * step.Time * step.Equipment.HourlyCost ) + step.Input.UnitCost;
                }
            return totalProductionCost;
        }
    }
}