using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.SelfLearningAndTesting
{
    internal class FamilyMemberSeminar1_2
    {
        public string name { get; set; }
        public Gender gender { get; set; }
        public FamilyMemberSeminar1_2[] children { get; set; }
        public FamilyMemberSeminar1_2 mother { get; set; }
        public FamilyMemberSeminar1_2 father { get; set; }

        public FamilyMemberSeminar1_2() { }

        public FamilyMemberSeminar1_2(string name, Gender gender, FamilyMemberSeminar1_2 mother, FamilyMemberSeminar1_2 father, params FamilyMemberSeminar1_2[]? children)
        {
            this.name = name;
            this.gender = gender;
            this.mother = mother;
            this.father = father;
            this.children = children;
        }

        public void MothersInFamily()
        {

        }
    }
}
