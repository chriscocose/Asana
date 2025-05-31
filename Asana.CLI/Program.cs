using Asana.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Asana
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var toDos = new List<ToDo>();
            var projects = new List<Project>();
            int itemCount = 0;
            int projectCount = 0;
            int choiceInt;

            do
            {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("1. Create a ToDo");
                Console.WriteLine("2. Delete a ToDo");
                Console.WriteLine("3. Update a ToDo");
                Console.WriteLine("4. List all ToDos");
                Console.WriteLine("5. Create a Project");
                Console.WriteLine("6. Delete a Project");
                Console.WriteLine("7. Update a Project");
                Console.WriteLine("8. List all Projects");
                Console.WriteLine("9. List all ToDos in a Given Project");
                Console.WriteLine("0. Exit");

                var choice = Console.ReadLine() ?? "0";

                if (int.TryParse(choice, out choiceInt))
                {
                    switch (choiceInt)
                    {
                        case 1:
                            Console.Write("Name: ");
                            var name = Console.ReadLine();
                            Console.Write("Description: ");
                            var description = Console.ReadLine();
                            Console.Write("Priority (1-5): ");
                            int.TryParse(Console.ReadLine(), out int priority);
                            Console.Write("Project Id: ");
                            int.TryParse(Console.ReadLine(), out int projectId);

                            toDos.Add(new ToDo
                            {
                                Id = ++itemCount,
                                Name = name,
                                Description = description,
                                Priority = priority,
                                IsCompleted = false,
                                ProjectId = projectId
                            });
                            Console.WriteLine("ToDo created successfully!");
                            break;

                        case 2:
                            ListToDos(toDos);
                            Console.Write("Enter ToDo Id to Delete: ");
                            int.TryParse(Console.ReadLine(), out int toDoDeleteId);
                            var toDoToDelete = toDos.FirstOrDefault(t => t.Id == toDoDeleteId);
                            if (toDoToDelete != null)
                            {
                                toDos.Remove(toDoToDelete);
                                Console.WriteLine("ToDo deleted.");
                            }
                            else
                            {
                                Console.WriteLine("ToDo not found.");
                            }
                            break;

                        case 3:
                            ListToDos(toDos);
                            Console.Write("Enter ToDo Id to Update: ");
                            int.TryParse(Console.ReadLine(), out int toDoUpdateId);
                            var toDoToUpdate = toDos.FirstOrDefault(t => t.Id == toDoUpdateId);

                            if (toDoToUpdate != null)
                            {
                                Console.Write("New Name: ");
                                toDoToUpdate.Name = Console.ReadLine();
                                Console.Write("New Description: ");
                                toDoToUpdate.Description = Console.ReadLine();
                                Console.Write("New Priority (1-5): ");
                                int.TryParse(Console.ReadLine(), out int newPriority);
                                toDoToUpdate.Priority = newPriority;
                                Console.Write("Is Completed (true/false): ");
                                bool.TryParse(Console.ReadLine(), out bool isCompleted);
                                toDoToUpdate.IsCompleted = isCompleted;
                                Console.WriteLine("ToDo updated.");
                            }
                            else
                            {
                                Console.WriteLine("ToDo not found.");
                            }
                            break;

                        case 4:
                            ListToDos(toDos);
                            break;

                        case 5:
                            Console.Write("Project Name: ");
                            var projectName = Console.ReadLine();
                            Console.Write("Project Description: ");
                            var projectDescription = Console.ReadLine();

                            projects.Add(new Project
                            {
                                Id = ++projectCount,
                                Name = projectName,
                                Description = projectDescription,
                                CompletePercent = 0
                            });
                            Console.WriteLine("Project created successfully!");
                            break;

                        case 6:
                            ListProjects(projects);
                            Console.Write("Enter Project Id to Delete: ");
                            int.TryParse(Console.ReadLine(), out int projectDeleteId);
                            var projectToDelete = projects.FirstOrDefault(p => p.Id == projectDeleteId);
                            if (projectToDelete != null)
                            {
                                projects.Remove(projectToDelete);
                                Console.WriteLine("Project deleted.");
                            }
                            else
                            {
                                Console.WriteLine("Project not found.");
                            }
                            break;

                        case 7:
                            ListProjects(projects);
                            Console.Write("Enter Project Id to Update: ");
                            int.TryParse(Console.ReadLine(), out int projectUpdateId);
                            var projectToUpdate = projects.FirstOrDefault(p => p.Id == projectUpdateId);
                            if (projectToUpdate != null)
                            {
                                Console.Write("New Project Name: ");
                                projectToUpdate.Name = Console.ReadLine();
                                Console.Write("New Description: ");
                                projectToUpdate.Description = Console.ReadLine();
                                Console.Write("New Complete Percent (0-100): ");
                                int.TryParse(Console.ReadLine(), out int completePercent);
                                projectToUpdate.CompletePercent = completePercent;
                                Console.WriteLine("Project updated.");
                            }
                            else
                            {
                                Console.WriteLine("Project not found.");
                            }
                            break;

                        case 8:
                            ListProjects(projects);
                            break;

                        case 9:
                            ListProjects(projects);
                            Console.Write("Enter Project Id to View ToDos: ");
                            int.TryParse(Console.ReadLine(), out int projectViewId);
                            var selectedProject = projects.FirstOrDefault(p => p.Id == projectViewId);
                            if (selectedProject != null)
                            {
                                Console.WriteLine($"\n--- ToDos for Project: {selectedProject.Name} ---");
                                foreach (var todo in toDos.Where(t => t.ProjectId == selectedProject.Id))
                                {
                                    Console.WriteLine(todo);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Project not found.");
                            }
                            break;

                        case 0:
                            Console.WriteLine("Exiting...");
                            break;

                        default:
                            Console.WriteLine("ERROR: Unknown menu selection");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine($"ERROR: {choice} is not a valid menu selection");
                }

            } while (choiceInt != 0);
        }

        static void ListToDos(List<ToDo> toDos)
        {
            Console.WriteLine("\n--- ToDos ---");
            foreach (var todo in toDos)
            {
                Console.WriteLine(todo);
            }
        }

        static void ListProjects(List<Project> projects)
        {
            Console.WriteLine("\n--- Projects ---");
            foreach (var project in projects)
            {
                Console.WriteLine(project);
            }
        }
    }
}
