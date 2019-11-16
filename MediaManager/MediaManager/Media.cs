using System;
using System.Collections.Generic;

namespace MediaManager
{
    public abstract class Media : IOrganize
    {
        public virtual void Play()
        {
            throw new NotImplementedException();
        }

        public virtual void Pause()
        {
            throw new NotImplementedException();
        }

        public virtual void Stop()
        {
            throw new NotImplementedException();
        }
        
        public virtual Media Create()
        {
            throw new System.NotImplementedException();
        }

        public virtual Media Read()
        {
            throw new System.NotImplementedException();
        }

        public virtual void Update()
        {
            throw new System.NotImplementedException();
        }

        public virtual void Delete()
        {
            throw new System.NotImplementedException();
        }

        public virtual LinkedList<Media> Search()
        {
            throw new System.NotImplementedException();
        }
    }
}