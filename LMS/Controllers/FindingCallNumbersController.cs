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
        private List<Pair>? correctNode;


        public IActionResult Index()
        {
            CreateTreeFile treeFile = new CreateTreeFile();

            

            if (treeFile.FileExists())
            {
                gameTree = treeFile.ReadFile();
            }
            else
            {
                treeFile.CreateFile();
                gameTree = treeFile.ReadFile();
            }

            correctNode = gameTree.GetPathToRandomNode(gameTree.Root, depth);

            var incorrectNodePath1 = gameTree.GetPathToRandomNode(gameTree.Root, depth);
            while (incorrectNodePath1[TOP_LEVEL] == correctNode[TOP_LEVEL])
            {
                incorrectNodePath1 = gameTree.GetPathToRandomNode(gameTree.Root, depth);
            }

            var incorrectNodePath2 = gameTree.GetPathToRandomNode(gameTree.Root, depth);
            while (incorrectNodePath2[TOP_LEVEL] == correctNode[TOP_LEVEL] || incorrectNodePath2[TOP_LEVEL] == incorrectNodePath1[TOP_LEVEL])
            {
                incorrectNodePath2 = gameTree.GetPathToRandomNode(gameTree.Root, depth);
            }

            var incorrectNodePath3 = gameTree.GetPathToRandomNode(gameTree.Root, depth);
            while (incorrectNodePath3[TOP_LEVEL] == correctNode[TOP_LEVEL] || incorrectNodePath3[TOP_LEVEL] == incorrectNodePath1[TOP_LEVEL] || incorrectNodePath3[TOP_LEVEL] == incorrectNodePath2[TOP_LEVEL])
            {
                incorrectNodePath3 = gameTree.GetPathToRandomNode(gameTree.Root, depth);
            }


            var model = new FindingCallNumbers
            {
                Question = Convert.ToInt32(correctNode[THIRD_LEVEL].Number),
                FirstLevel = new List<Pair> { correctNode[TOP_LEVEL], incorrectNodePath1[TOP_LEVEL], incorrectNodePath2[TOP_LEVEL], incorrectNodePath3[TOP_LEVEL] },
                SecondLevel = GetNextLevel(correctNode[TOP_LEVEL]),
                ThirdLevel = GetNextLevel(correctNode[SECOND_LEVEL])
            };

            model.SortLevels();

            return View(model);
        }

        private List<Pair> GetNextLevel(Pair node)
        {
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
            int numLevel = Convert.ToInt32(level);
            return Json(true);
        }

        


    }

}