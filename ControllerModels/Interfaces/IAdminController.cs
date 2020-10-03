using System;
using System.Collections.Generic;
using System.Text;

namespace ControllerModels
{
    public interface IAdminController
    {
        void PostIngredient(IngredientToPost ingredientToPost);
        void PostRecipe(RecipeSimpleToPost recipeSimpleToPost);
        void PostDesease(DeseaseToPost deseaseToPost);
        void PostDiet(DietToPost dietToPost);
        void PostInstrument(InstrumentToPost instrumentToPost);
        void PostProducer(ProducerToPost producerToPost);

        void UpdateTransaltion(Translation translation);
    }
}