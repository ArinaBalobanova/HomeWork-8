﻿using System;
using HomeWork2.Classes;
using Task = HomeWork2.Classes.Task;

namespace HomeWork2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Написать программу, содержащую решение следующих задач:
            Task Manager 
            У команды из IT компании существует программа, где они контролируют свои текущие задачи – что-то типа Task Manager.
            Существует проекты по каждому проекту создаются задачи. Сущность Проект может быть в трех статусах: Проект, Исполнение, Закрыт.
            У проекта есть: описание проекта,сроки выполнения, инициатор проекта(заказчик), человек, ответственный за проект(тимлид),
            задачи по проекту, статус.
            Задачи по проекту назначает только один человек(тимлид) Сущность Задача может быть в четырех статусах: Назначена, В работе, На проверке, Выполнена.
            У задачи есть: описание задачи, сроки задачи,инициатор задачи, исполнитель, статус задачи,отчет(ы) по задаче
            Сущность Отчёт: текст отчета, дата выполнения, исполнитель.
            Описание процесса:
            Создается проект с определенными сроками. Далее ответственный за проект создает задачи по этому проекту.
            Задачи можно создавать только в статусе проекта «Проект». После того, как все проекты назначены необходимо перевести проект в статус «Исполнение».
            Задачи приходят исполнителям в статусе «Назначена». Исполнитель может взять задачу в работу, делегировать ее другому
            человеку или отклонить. Если человек берет задачу в работу, то задача переходит в статус «В работе», если он
            делегировал эту задачу, то меняется исполнитель, а статус становится «Назначена», при отклонении задачи, задача не имеет
            Исполнителя и Человек, назначивший задачу, может ее назначить кому-то другому или удалить эту задачу вообще. По каждой задаче создается отчет по выполненной работе.
            Отчет приходит инициатору на проверку. Отчет можно утвердить или вернуть на доработку. Проект считается закрытым, если по
            нему выполнены все задачи. Необходимо создать 10 человек команды, каждый человек должен получить минимум одну задачу.*/
            Console.WriteLine("Задание Task Manager");
            var projects = new List<Project>();
            string[] teamMembers = { "Арина", "Зарина", "Руслана", "Катя", "Азалия", "Ангелина", "Анжела", "Даша", "Алия", "Далия" };

            Project project = new Project("Создание веб-сайта", DateTime.Now.AddMonths(2), "Клиент", "Тимлид");
            projects.Add(project);

            for (int i = 0; i < 10; i++)
            {
                var task = new Task($"Задача {i + 1}", DateTime.Now.AddDays(30), "Клиент");
                task.AssignTo(teamMembers[i % teamMembers.Length]);
                project.AddTask(task);
            }
            project.StartProject();
            foreach (Task task in project.Tasks)
            {
                Console.WriteLine($"Задача: {task.Description}, Выполняет: {task.Performer}, Статус: {task.Status}");
            }
            foreach (Task task in project.Tasks)
            {
                task.Start();
                task.Complete("Задача выполнена.");
            }

            if (project.IsCompleted())
            {
                Console.WriteLine("Проект выполнен и завершен.");
            }
        }
    }
}