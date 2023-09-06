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
        }
        public double GetProductionCost()
        {
            double costoInsumos = 0.0;
            double costoEquipamiento = 0.0;

            foreach (Step step in this.steps)
            {
                costoInsumos += step.Input.UnitCost;
                costoEquipamiento += ((step.Time  * step.Equipment.HourlyCost)/60); 
            }

            return costoInsumos + costoEquipamiento;
        }
        
    }
}
/*para asignar esta responsabilidad, utilizamos el principio srp, ya que esta clase "receta" es la encargada
tanto de tener la responsabilidad de decir las cantidades de materiales y procedimiento como también la responsabilidad
de decir el costo total de la receta.*/