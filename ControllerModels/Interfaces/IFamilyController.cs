using System.Collections.Generic;
using ControllerModels;

namespace ControllerModels
{
    public interface IFamilyController
    {
        void AddDeseaseToBL(int Desease);
        void AddDietToBL(int Diet);
        void AddFlagToBL(int flag);
        void AddIngredientToBL(int ingredient);
        IEnumerable<int> GetFamilyMembers(string user);
        FamMemberToSent GetFamMemberDetail(int famMember);
        IEnumerable<KeyValuePair<string, int>> GetListDesease(int lang);
        IEnumerable<KeyValuePair<string, int>> GetListDiet(int lang);
        IEnumerable<KeyValuePair<string, int>> GetListFlag(int lang);
        IEnumerable<KeyValuePair<string, int>> GetListIngredient(int lang);
        void PostFamilyMember(FamMemberToPost famMemberToPost, string user);
        void UpdateFamMemberDetail(FamMemberToPost famMemberToPost, string user);
    }
}