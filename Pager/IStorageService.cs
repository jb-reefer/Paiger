using System;
using System.IO;

namespace Pager
{
    public interface IStorageService
    {
        Uri UploadStreamAs(Stream stream, string name);
    }
}