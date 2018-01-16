using System;
using System.Collections.Generic;
using System.Text;

namespace todolist
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
    }
}
