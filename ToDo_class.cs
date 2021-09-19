using System;
using MySqlConnector;

namespace Project_ToDo
{
    public class ToDo
    {

        //private string previousTodo;
        //private string nextTodo;
        private string date, category, priority, task;

        public ToDo()
        {

        }

       /* public string getNext()
        {
            return this.nextTodo;
        }

        public string getPrevious()
        {
            return this.previousTodo;
        }

        public void removeTodo()
        {
            this.previousTodo.nextTodo = this.nextTodo;
            this.nextTodo.previousTodo = this.previousTodo;
        }

        public void addTodo(string todo)
        {
            if (this.nextTodo != null)
            {
                this.nextTodo.previousTodo = todo;
            }

            todo.nextTodo = this.nextTodo;
            this.nextTodo = todo;
            todo.previousTodo = this;*/

        }

        public ToDo(string date, string task, string category, string priority)
        {
            this.date = date;
            this.task = task;
            this.category = category;
            this.priority = priority;
        }

        public string getDate()
        {
            return this.date;
        }

        public void setDate(string date)
        {
            this.date = date;
        }

        public string getTask()
        {
            return this.task;
        }
        public void setTask(string task)
        {
            this.task = task;
        }

        public string getPriority()
        {
            return this.priority;
        }
        public void setPriority(string priority)
        {
            this.priority = priority;
        }

        public string getCategory()
        {
            return this.category;
        }
        public void setCategory(string category)
        {
            this.category = category;
        } 
    }
}        