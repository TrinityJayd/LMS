using LMS.Models;
using LMS_Management.FindingCallNumbers;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LMS.Controllers
{
    public class FindingCallNumbersController : Controller
    {
        private int TOP_LEVEL = 0;
        private int SECOND_LEVEL = 1;
        private int THIRD_LEVEL = 2;
        private int depth = 3;
        private Tree<Pair> gameTree;
        private static List<Pair>? correctPath;

        public IActionResult Index()
        {
            CreateTreeFile treeFile = new CreateTreeFile();
            

            if (treeFile.FileExists())
            {
                //If the file exists read the tree
                gameTree = treeFile.ReadFile();
            }
            else
            {
                //If the tree data file doesnt exist then create it
                treeFile.CreateFile();
                gameTree = treeFile.ReadFile();
            }

            correctPath = gameTree.GetPathToRandomNode(gameTree.Root, depth);

            var incorrectNodePath1 = gameTree.GetPathToRandomNode(gameTree.Root, depth);
            //Check the uniqueness of the paths so that there are no duplicates

            while (incorrectNodePath1[TOP_LEVEL] == correctPath[TOP_LEVEL])
            {
                incorrectNodePath1 = gameTree.GetPathToRandomNode(gameTree.Root, depth);
            }

            var incorrectNodePath2 = gameTree.GetPathToRandomNode(gameTree.Root, depth);
            while (incorrectNodePath2[TOP_LEVEL] == correctPath[TOP_LEVEL] || incorrectNodePath2[TOP_LEVEL] == incorrectNodePath1[TOP_LEVEL])
            {
                incorrectNodePath2 = gameTree.GetPathToRandomNode(gameTree.Root, depth);
            }

            var incorrectNodePath3 = gameTree.GetPathToRandomNode(gameTree.Root, depth);
            while (incorrectNodePath3[TOP_LEVEL] == correctPath[TOP_LEVEL] || incorrectNodePath3[TOP_LEVEL] == incorrectNodePath1[TOP_LEVEL] || incorrectNodePath3[TOP_LEVEL] == incorrectNodePath2[TOP_LEVEL])
            {
                incorrectNodePath3 = gameTree.GetPathToRandomNode(gameTree.Root, depth);
            }


            var model = new FindingCallNumbers
            {
                Question = correctPath[THIRD_LEVEL].Description,
                FirstLevel = new List<Pair> { correctPath[TOP_LEVEL], incorrectNodePath1[TOP_LEVEL], incorrectNodePath2[TOP_LEVEL], incorrectNodePath3[TOP_LEVEL] },
                SecondLevel = GetNextLevel(correctPath[TOP_LEVEL]),
                ThirdLevel = GetNextLevel(correctPath[SECOND_LEVEL])
            };

            model.SortLevels();
            

            return View(model);
        }

        private List<Pair> GetNextLevel(Pair node)
        {
            //get the children of the parent node
            var children = gameTree.GetChildren(node);

            if(children.Count <= 4)
            {
                return children;
            }
            else
            {
                //Get 4 random children 
                var randomChildren = children.OrderBy(x => Guid.NewGuid()).Take(4).ToList();
                return randomChildren;
            }
        }

        public IActionResult Check(string selectedOption, string level)
        {
            //The level tells us what level the node is at
            int numLevel = Convert.ToInt32(level);

            if (!string.IsNullOrEmpty(selectedOption))
            {
                //The choice is sent to the controller as a string number:description
                string[] choice = selectedOption.Split(':');
                Pair userPair = new Pair()
                {
                    Number = choice[0],
                    Description = choice[1]
                };

                switch (numLevel)
                {
                    case 0:
                        if (correctPath[TOP_LEVEL].CompareObj(userPair))
                        {
                            return Json(true);
                        }
                        break;
                    case 1:
                        if (correctPath[SECOND_LEVEL].CompareObj(userPair))
                        {
                            return Json(true);
                        }
                        break;
                    case 2:
                        if (correctPath[THIRD_LEVEL].CompareObj(userPair))
                        {
                            return Json(true);
                        }
                        break;
                    default:
                        return Json(false);
                }
            }
          
            return Json(false);
        }

        


    }

}