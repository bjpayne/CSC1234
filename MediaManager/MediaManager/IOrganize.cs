using System.Collections.Generic;

namespace MediaManager
{
    interface IOrganize
    {
        Media Create();

        Media Read();

        void Update();

        void Delete();

        LinkedList<Media> Search();
    }
}