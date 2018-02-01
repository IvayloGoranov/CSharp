using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P4NestedRectangles.Models;

namespace P4NestedRectangles
{
    public class NestedRectanglesMain
    {
        static List<Rectangle> rectangles = new List<Rectangle>();
        static void Main()
        {
            ReadInput();
            rectangles = rectangles.OrderBy(rectangle => rectangle.TopLeftPoint.X).ToList();
            List<Rectangle> result = FindLongestSequnceOfNestedRectangles(rectangles);
            Console.WriteLine(string.Join(" < ", result));
        }

        private static List<Rectangle> FindLongestSequnceOfNestedRectangles(List<Rectangle> rectangles)
        {
            int[] longestSeqLengths = new int[rectangles.Count];
            int[] previous = new int[rectangles.Count];
            for (int x = 0; x < rectangles.Count; x++)
            {
                longestSeqLengths[x] = 1;
                previous[x] = -1;
                for (int i = 0; i < x; i++)
                {
                    //Checks if the first rectangle is nested in the second one.
                    if (IsNested(rectangles[x] , rectangles[i]) && (longestSeqLengths[i] + 1 > longestSeqLengths[x]))
                    {
                        longestSeqLengths[x] = longestSeqLengths[i] + 1;
                        previous[x] = i;
                    }
                }
            }
            int maxLength = longestSeqLengths.Max();
            List<List<Rectangle>> results = new List<List<Rectangle>>();
            for (int index = 0; index < longestSeqLengths.Length; index++)
			{
			    if (longestSeqLengths[index] == maxLength)
	            {
		            List<Rectangle> currentSequence = DetermineCurrentSequence(index, previous);
                    results.Add(currentSequence);
	            }
			}
            if (results.Count > 1)
            {
                var currentListFirstAlphabetically = results[0];
                for (int i = 1; i < results.Count; i++)
                {
                    var nextListToCompareWith = results[i];
                    for (int j = 0; j < results.Count; j++)
                    {
                        if (nextListToCompareWith[j].Name != currentListFirstAlphabetically[j].Name)
                        {
                            if (nextListToCompareWith[j].CompareTo(currentListFirstAlphabetically[j]) < 0) //Next list comes before
                            {                                                                               //current alphabetically.
                                currentListFirstAlphabetically = nextListToCompareWith;    
                            }
                            break;  //We compare the sequnces by the first pair of rectangles with unequal names.
                        }
                    }
                }
                return currentListFirstAlphabetically;
            }
            else
            {
                return results[0];
            }
        }

        private static List<Rectangle> DetermineCurrentSequence(int lastIndex, int[] previous)
        {
            List<Rectangle> result = new List<Rectangle>();
            while (lastIndex != -1)
            {
                result.Add(rectangles[lastIndex]);
                lastIndex = previous[lastIndex];
            }
            result.Reverse();
            return result;
        }

        private static bool IsNested(Rectangle firstRectangle, Rectangle secondRectangle) //Is the first rectangle nested
        {                                                                                 //in the second one.  
            bool isNested = firstRectangle.TopLeftPoint.X >= secondRectangle.TopLeftPoint.X &&
               firstRectangle.BottomRightPoint.X <= secondRectangle.BottomRightPoint.X &&
               firstRectangle.TopLeftPoint.Y <= secondRectangle.TopLeftPoint.Y &&
               firstRectangle.BottomRightPoint.Y >= secondRectangle.BottomRightPoint.Y;
            return isNested;

        }

        private static void ReadInput()
        {
            while (true)
            {
                string inputLine = Console.ReadLine();
                if (inputLine == "End")
                {
                    break;
                }
                string[] inputArgs = inputLine.Split(new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                
                if (inputArgs.Length != 5)
                {
                    throw new ArgumentException
                        ("Invalid input. Each rectangle should come in format \"name: left top right bottom\"");   
                }
                
                string rectangleName = inputArgs[0];
                try
                {
                    var isRectangleDuplicateByName = rectangles.Any(r => r.Name == rectangleName);
                    if (isRectangleDuplicateByName)
                    {
                        throw new ArgumentException(string.Format("Rectangle with name {0} already created.", rectangleName));
                    }
                    
                    int rectangleTopLeftX = int.Parse(inputArgs[1]);
                    int rectangleTopLeftY = int.Parse(inputArgs[2]);
                    int rectangleBottomRightX = int.Parse(inputArgs[3]);
                    int rectangleBottomRightY = int.Parse(inputArgs[4]);
                    
                    bool isRectangleValid = rectangleTopLeftX < rectangleBottomRightX || rectangleTopLeftY > rectangleBottomRightY;
                    if (isRectangleValid == false)
                    {
                        throw new ArgumentException("Invalid rectangle. Valid rectangle coordinates: left < right, top > bottom");
                    }
                    
                    var rectangle = new Rectangle(rectangleName, new Point(rectangleTopLeftX, rectangleTopLeftY),
                        new Point(rectangleBottomRightX, rectangleBottomRightY));
                    
                    var isRectangleDuplicateByCoordinates = rectangles.
                        Any(r => r.TopLeftPoint.X == rectangle.TopLeftPoint.X 
                            && r.TopLeftPoint.Y == rectangle.TopLeftPoint.Y
                            && r.BottomRightPoint.X == rectangle.BottomRightPoint.X
                            && r.BottomRightPoint.Y == rectangle.BottomRightPoint.Y);
                    if (isRectangleDuplicateByCoordinates)
                    {
                        throw new ArgumentException(string.Format("Rectangle with name {0} already created.", rectangleName));
                    }
                    
                    rectangles.Add(rectangle);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                }
            }
        }
    }
}
