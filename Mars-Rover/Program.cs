using System;
using System.Collections.Generic;

namespace Mars_Rover
{
    internal class Program
    {
        /*
         * İLYAS GEDİKOĞLU - MARS ROVER PROJECT
         */

        /*
         * After entering the input values, press the enter key to see the output value.
         */

        //It is the list variable that will hold the input values.
        static List<string> inputList = new List<string>();

        //It is the variable that will hold the upper right coordinate value.
        static string[] upperRightCoordinates = new string[3];

        static void Main(string[] args)
        {
            //We get the upper right coordinate value from the user.
            var upperRightCoordinate = Console.ReadLine();
            if (!string.IsNullOrEmpty(upperRightCoordinate))
            {
                //If the value is not empty, we divide the value according to the spaces and assign it to our variable.
                upperRightCoordinates = upperRightCoordinate.Split(' ');

                if (upperRightCoordinates.Length == 2)
                {
                    //I created an infinite loop to enter an input value until the enter key is pressed.
                    while (true)
                    {
                        var input = Console.ReadLine();

                        //If the entered value is empty, the loop is exited.
                        if (string.IsNullOrEmpty(input))
                            break;
                        else
                            //If the entered value is not empty, it is added to the input list.
                            inputList.Add(input);
                    }

                    //This function is called to start the navigation when the input entries are finished.
                    StartRover();
                }
                else
                    Console.WriteLine("Plateau coordinates were entered incorrectly.");
            }
        }

        static void StartRover ()
        {
            //Each rover has two input values. So we increment the i of your loop by 2.
            for (int i = 0; i < inputList.Count; i+=2)
            {
                //The input value where the coordinate and direction is specified is checked.
                if (string.IsNullOrEmpty(inputList[i]))
                    Console.WriteLine("The input value was not found.");
                else
                {
                    //The input value specifying the coordinate and direction is divided by looking at the spaces.
                    var input1 = inputList[i].Split(' ');

                    //Checking the accuracy of the input value.
                    if (input1.Length < 3 || input1.Length > 3)
                        Console.WriteLine("Rover's location information is missing or entered incorrectly.");
                    else
                    {
                        //Creating the Rover object. The first parameter is the x coordinate, the second parameter is the y coordinate, and the third parameter is the direction.
                        Rover rover = new Rover(Convert.ToInt32(input1[0]), Convert.ToInt32(input1[1]), Convert.ToChar(input1[2]));

                        //The input value that specifies the movements to be made by the rover is checked.
                        if (string.IsNullOrEmpty(inputList[i + 1]))
                        {
                            Console.WriteLine("The list of moves that the Rover will explore the plateau has not been sent.");
                        }
                        else
                        {
                            //The letters in the input value indicating the movements that the rover will do are looked at.
                            for (int y = 0; y < inputList[i + 1].Length; y++)
                            {
                                //If the letter read is L, the "Left" function is called to make the rover turn left.
                                if (inputList[i + 1][y] == 'L')
                                    rover.Left();
                                //If the letter read is L, the "Right" function is called to make the rover turn left.
                                else if (inputList[i + 1][y] == 'R')
                                    rover.Right();
                                //If the letter read is M, the "Move" function is called to move the rover 1 grid forward.
                                else if (inputList[i + 1][y] == 'M')
                                    rover.Move(Convert.ToInt32(upperRightCoordinates[0]), Convert.ToInt32(upperRightCoordinates[1]));
                                //If the letter read is not L, R or M, an incorrect input message is returned.
                                else
                                    Console.WriteLine("The list of moves for which Rover will explore the plateau has been sent incorrectly.");
                            }

                            //The rover's output is printed on the screen.
                            Console.WriteLine(rover.Get_X_Coordinate() + " " + rover.Get_Y_Coordinate() + " " + rover.Get_Direction());
                        }
                    }
                }
            }
        }
    }
}
