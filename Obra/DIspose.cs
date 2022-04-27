namespace Obra;
using System;
using System.ComponentModel;

public interface IDisposable
{
    
}
public class Dispose
{
    public class MyResource: IDisposable
    {
       
        private IntPtr handle;
        
        private Component component = new Component();
        
        private bool disposed = false;

        //constructor
        public MyResource(IntPtr handle)
        {
            this.handle = handle;
        }
        
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        
        protected virtual void Dispose(bool disposing)
        {
            // been called ?
            if(!this.disposed)
            {
                if(disposing)
                {
                    component.Dispose();
                }
                
                CloseHandle(handle);
                handle = IntPtr.Zero;

                //disposing done
                disposed = true;
            }
        }
        
        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);

        //finalizer pour class, ne pas reécrire dans les héritages
        ~MyResource()
        {
            Dispose(disposing: false);
        }
    }
}