using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Management.FindingCallNumbers
{
    public class PopulateTree
    {
        public Tree<Pair> CreateTree()
        {
            Pair basePair = new Pair { Number = "", Description = "ROOT" };
            Tree<Pair> tree = new Tree<Pair>(basePair);

            List<Pair> level1 = new List<Pair>()
            {
                new Pair { Number = "100", Description = "Philosophy & psychology" },
                new Pair { Number = "200", Description = "Religion" },
                new Pair { Number = "300", Description = "Social Sciences" },
                new Pair { Number = "400", Description = "Language" },
                new Pair { Number = "500", Description = "Natural science & mathematics" },
                new Pair { Number = "600", Description = "Technology (applied sciences)" },
                new Pair { Number = "700", Description = "Arts & Recreation" },
                new Pair { Number = "800", Description = "Literature" }
            };

            //LEVEL 1
            tree.AddChildren(basePair, level1);

            List<Pair> L100 = PhilosphyL2();
            List<Pair> L200 = ReligionsL2();
            List<Pair> L300 = SocialSciencesL2();
            List<Pair> L400 = LanguageL2();
            List<Pair> L500 = NaturalScienceL2();
            List<Pair> L600 = TechnologyL2();
            List<Pair> L700 = ArtsL2();
            List<Pair> L800 = LiteratureL2();


            //LEVEL 2
            tree.AddChildren(level1[0], L100);
            tree.AddChildren(level1[1], L200);
            tree.AddChildren(level1[2], L300);
            tree.AddChildren(level1[3], L400);
            tree.AddChildren(level1[4], L500);
            tree.AddChildren(level1[5], L600);
            tree.AddChildren(level1[6], L700);
            tree.AddChildren(level1[7], L800);


            //LEVEL 3
            tree.AddChildren(L100[0], Metaphysics());
            tree.AddChildren(L100[1], Epistemology());
            tree.AddChildren(L100[2], Ethics());

            tree.AddChildren(L200[0], TheoryOfReligion());

            tree.AddChildren(L300[0], Economics());
            tree.AddChildren(L300[1], Law());
            tree.AddChildren(L300[2], SocialProblems());

            tree.AddChildren(L400[0], Linguistics());

            tree.AddChildren(L500[0], Mathematics());
            tree.AddChildren(L500[1], Physics());
            tree.AddChildren(L500[2], Biology());

            tree.AddChildren(L600[0], Medicine());
            tree.AddChildren(L600[1], Agriculture());
            tree.AddChildren(L600[2], Home());
            tree.AddChildren(L600[3], Management());

            tree.AddChildren(L700[0], Sculpture());
            tree.AddChildren(L700[1], Painting());

            tree.AddChildren(L800[0], English());

            return tree;
        }

        public List<Pair> PhilosphyL2()
        {
            List<Pair> level2 = new List<Pair>()
            {
                new Pair { Number = "110", Description = "Metaphysics" },
                new Pair { Number = "120", Description = "Epistemology" },
                new Pair { Number = "170", Description = "Ethics" }
            };

            return level2;
        }

        public List<Pair> Metaphysics()
        {
            List<Pair> level3 = new List<Pair>()
            {
                new Pair { Number = "114", Description = "Space" },
                new Pair { Number = "115", Description = "Time" },
                new Pair { Number = "116", Description = "Change" },
                new Pair { Number = "117", Description = "Structure" }
            };
            return level3;
        }

        public List<Pair> Epistemology()
        {
            List<Pair> level3 = new List<Pair>()
            {
                new Pair { Number = "122", Description = "Causation" },
                new Pair { Number = "126", Description = "The self" },
                new Pair { Number = "127", Description = "The unconscious and the subconscious" },
                new Pair { Number = "128", Description = "Humankind" }
            };
            return level3;
        }

        public List<Pair> Ethics()
        {
            List<Pair> level3 = new List<Pair>()
            {
                new Pair { Number = "171", Description = "Ethical systems" },
                new Pair { Number = "172", Description = "Political ethics" },
                new Pair { Number = "173", Description = "Ethics of family relationships" },
                new Pair { Number = "174", Description = "Occupational ethics" }
            };
            return level3;
        }

        public List<Pair> ReligionsL2()
        {
            List<Pair> level2 = new List<Pair>()
            {
                new Pair { Number = "210", Description = "Philosophy and theory of religion" },
            };

            return level2;
        }

        public List<Pair> TheoryOfReligion()
        {
            List<Pair> level3 = new List<Pair>()
            {
                new Pair { Number = "211", Description = "Concepts of God" },
                new Pair { Number = "213", Description = "Creation" },
                new Pair { Number = "214", Description = "Theodicy" },
                new Pair { Number = "215", Description = "Science and religion" }
            };
            return level3;
        }

        public List<Pair> SocialSciencesL2()
        {
            List<Pair> level2 = new List<Pair>()
            {
                new Pair { Number = "330", Description = "Economics" },
                new Pair { Number = "340", Description = "Law" },
                new Pair { Number = "360", Description = "Social problems and social services" }
            };
            return level2;
        }

        public List<Pair> Economics()
        {
            List<Pair> level3 = new List<Pair>()
            {
                new Pair { Number = "331", Description = "Labor economics" },
                new Pair { Number = "332", Description = "Financial economics" },
                new Pair { Number = "336", Description = "Public finance" },
                new Pair { Number = "338", Description = "Production" }
            };
            return level3;
        }

        public List<Pair> Law()
        {
            List<Pair> level3 = new List<Pair>()
            {
                new Pair { Number = "345", Description = "Criminal law" },
                new Pair { Number = "346", Description = "Private law" },
                new Pair { Number = "347", Description = "Procedure and courts" },
                new Pair { Number = "348", Description = "Laws, regulations, cases" }
            };
            return level3;
        }

        public List<Pair> SocialProblems()
        {
            List<Pair> level3 = new List<Pair>()
            {
                new Pair { Number = "364", Description = "Criminology" },
                new Pair { Number = "365", Description = "Penal and related institutions" },
                new Pair { Number = "366", Description = "Secret associations and societies" },
                new Pair { Number = "368", Description = "Insurance" }
            };
            return level3;
        }

        public List<Pair> LanguageL2()
        {
            List<Pair> level2 = new List<Pair>()
            {
                new Pair { Number = "410", Description = "Linguistics" },
            };
            return level2;
        }

        public List<Pair> Linguistics()
        {
            List<Pair> level3 = new List<Pair>()
            {
                new Pair { Number = "411", Description = "Writing systems" },
                new Pair { Number = "412", Description = "Etymology" },
                new Pair { Number = "413", Description = "Dictionaries" },
                new Pair { Number = "414", Description = "Phonology and phonetics" }
            };
            return level3;
        }

        public List<Pair> NaturalScienceL2()
        {
            List<Pair> level2 = new List<Pair>()
            {
                new Pair { Number = "510", Description = "Mathematics" },
                new Pair { Number = "530", Description = "Physics" },
                new Pair { Number = "570", Description = "Biology" }
            };
            return level2;
        }

        public List<Pair> Mathematics()
        {
            List<Pair> level3 = new List<Pair>()
            {
                new Pair { Number = "512", Description = "Algebra" },
                new Pair { Number = "513", Description = "Arithmetic" },
                new Pair { Number = "515", Description = "Analysis" },
                new Pair { Number = "516", Description = "Geometry" }
            };
            return level3;
        }

        public List<Pair> Physics()
        {
            List<Pair> level3 = new List<Pair>()
            {
                new Pair { Number = "512", Description = "Sound and related vibrations" },
                new Pair { Number = "513", Description = "Light and related radiation" },
                new Pair { Number = "515", Description = "Heat" },
                new Pair { Number = "516", Description = "Magnetism" }
            };
            return level3;
        }

        public List<Pair> Biology()
        {
            List<Pair> level3 = new List<Pair>()
            {
                new Pair { Number = "571", Description = "Physiology and related subjects" },
                new Pair { Number = "572", Description = "Biochemistry" },
                new Pair { Number = "576", Description = "Genetics and evolution" },
                new Pair { Number = "577", Description = "Ecology" }
            };
            return level3;
        }

        public List<Pair> TechnologyL2()
        {
            List<Pair> level2 = new List<Pair>()
            {
                new Pair { Number = "610", Description = "Medicine and health" },
                new Pair { Number = "630", Description = "Agriculture" },
                new Pair { Number = "640", Description = "Home and family management" },
                new Pair { Number = "650", Description = "Management and public relations" }
            };
            return level2;
        }

        public List<Pair> Medicine()
        {
            List<Pair> level3 = new List<Pair>()
            {
                new Pair { Number = "611", Description = "Human anatomy, cytology, histology" },
                new Pair { Number = "613", Description = "Personal health and safety" },
                new Pair { Number = "615", Description = "Pharmacology and therapeutics" },
                new Pair { Number = "616", Description = "Diseases" }
            };
            return level3;
        }

        public List<Pair> Agriculture()
        {
            List<Pair> level3 = new List<Pair>()
            {
                new Pair { Number = "632", Description = "Plant injuries, diseases, pests" },
                new Pair { Number = "633", Description = "Field and plantation crops" },
                new Pair { Number = "634", Description = "Orchards, fruits, forestry" },
                new Pair { Number = "637", Description = "Processing dairy and related products" }
            };
            return level3;
        }

        public List<Pair> Home()
        {
            List<Pair> level3 = new List<Pair>()
            {
                new Pair { Number = "642", Description = "Meals and table service" },
                new Pair { Number = "643", Description = "Housing and household equipment" },
                new Pair { Number = "645", Description = "Household furnishings" },
                new Pair { Number = "648", Description = "Housekeeping" }
            };
            return level3;
        }

        public List<Pair> Management()
        {
            List<Pair> level3 = new List<Pair>()
            {
                new Pair { Number = "651", Description = "Office services" },
                new Pair { Number = "652", Description = "Processes of written communication" },
                new Pair { Number = "653", Description = "Shorthand" },
                new Pair { Number = "657", Description = "Accounting" },
                new Pair { Number = "658", Description = "General management" },
                new Pair { Number = "659", Description = "Advertising and public relations" }
            };
            return level3;
        }

        public List<Pair> ArtsL2()
        {
            List<Pair> level2 = new List<Pair>()
            {
                new Pair { Number = "730", Description = "Sculpture, ceramics and metalwork" },
                new Pair { Number = "750", Description = "Painting" }
            };
            return level2;
        }

        public List<Pair> Sculpture()
        {
            List<Pair> level3 = new List<Pair>()
            {
                new Pair
                {
                    Number = "731",
                    Description = "Processes, forms, subjects of sculpture"
                },
                new Pair { Number = "736", Description = "Carving and carvings" },
                new Pair { Number = "738", Description = "Ceramic arts" },
                new Pair { Number = "739", Description = "Art metalwork" }
            };
            return level3;
        }

        public List<Pair> Painting()
        {
            List<Pair> level3 = new List<Pair>()
            {
                new Pair { Number = "752", Description = "Color" },
                new Pair { Number = "753", Description = "Symbolism, allegory, mythology, legend" },
                new Pair { Number = "754", Description = "Genre paintings" },
                new Pair { Number = "755", Description = "Religion" }
            };
            return level3;
        }

        public List<Pair> LiteratureL2()
        {
            List<Pair> level2 = new List<Pair>()
            {
                new Pair { Number = "820", Description = "English and Old English literatures" }
            };
            return level2;
        }

        public List<Pair> English()
        {
            List<Pair> level3 = new List<Pair>()
            {
                new Pair { Number = "821", Description = "English Poetry" },
                new Pair { Number = "822", Description = "English drama" },
                new Pair { Number = "823", Description = "English fiction" },
                new Pair { Number = "824", Description = "English essays" }
            };
            return level3;
        }
    }
}
