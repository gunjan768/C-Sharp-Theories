using System;

namespace AdvancedCourse
{

    // Delegate is an object that knows how to call a method (or group of methods). It is a reference to a method. We need
    // it for designing extensible and flexible applications (example framework).
    // When to use a delegate: a) An eventing design pattern is used    b) The caller doesn't need to access other properties or
    // methods on the object implementing the method.
    public class Photo
    {
        public static Photo Load(string path)
        {
            return new Photo();
        }

        public void Save()
        {

        }
    }

    public class PhotoFilters
    {
        public void ApplyBrightness(Photo photo)
        {
            System.Console.WriteLine("Apply brightness");
        }

        public void ApplyContrast(Photo photo)
        {
            System.Console.WriteLine("Apply contrast");
        }
    }

    public class PhotoProcessor
    {
        // User defined delegate
        public delegate void PhotoFilterHandler(Photo photo);

        // Using hard code
        public void Process(string path)
        {
            var photo = Photo.Load(path);

            var filters = new PhotoFilters();
            filters.ApplyBrightness(photo);
            filters.ApplyContrast(photo);

            photo.Save();
        }

        // Using user defined delegate
        public void ProcessDelegate(string path, PhotoFilterHandler photoFilterHandler)
        {
            // Base class of delegate is MultiCastDelegate. Delegate allows to have single function pointer where as MultiCastDelegate
            // allows to have multiple functions pointer.

            // In .Net Framework, there are in-built delegates: Action (comes in two forms... a) Action and b) Generic: Action<>)
            // and Func. Func points to a method that returns a value where as Action points to a method that returns void.

            var photo = Photo.Load(path);

            // Now ProcessDelegate() method doesn't know what filter is applied to photo and now it is the responsibility
            // of photoFilterHandler() (or the client/developer who is handling photoFilterHandler() method).
            photoFilterHandler(photo);

            photo.Save();
        }

        // Using in-built delegates
        public void ProcessBuiltDelegate(string path, Action<Photo> photoFilterHandler)
        {
            var photo = Photo.Load(path);

            var filters = new PhotoFilters();
            photoFilterHandler(photo);

            photo.Save();
        }
    }

    public class Book
    {
        public int Id { get; set; }
    }
}