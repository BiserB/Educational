using System;
using System.Collections.Generic;
using System.Text;

namespace t01_EventImplementation
{
    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);
     
    public class Dispatcher
    {
        public event NameChangeEventHandler NameChange;

        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                name = value;
                OnNameChange(new NameChangeEventArgs(value));
            }
        }

        public void SetNewName(string newName)
        {
            this.Name = newName;
        }

        protected virtual void OnNameChange(NameChangeEventArgs args)
        {
            if (NameChange != null)
            {
                NameChange(this, args);
            }
        }
    }
}
