using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Widget decor1 = new RippleDecorator (new ScrollDecorator (new BorderDecorator (new TextField(5, 5))));
            // makes a Widget object that calls through a series of decorators before displaying the TextField using each
            // as an argument

            decor1.draw();
            //Calls .draw() in RippleDecorator

            Console.ReadLine();
            //To stop the window from exiting automatically
        }

        
    }

   abstract class  Widget
    {
        //needed to be abstract for the rest to work properly
        public Widget()
        {

        }
       

        public abstract void draw();
        
    }

    class TextField : Widget
    {
        private int width;
        private int height;

       public TextField(int w, int h)
        {
            width = w;
            height = h;
        }

        public override void draw()
        {
            

            Console.WriteLine("Text field of height " + height + " and width " + width);

           
        }
    }

    abstract class Decorator : Widget
    {
       public Widget wid;


        //Needed to be abstract to make rest work properly
       public Decorator(Widget w)
        {
            wid = w;
        }

        public override void draw()
        {

        }
    }

    class BorderDecorator : Decorator
    {

       
       public BorderDecorator(Widget w) : base(w)
        {
            wid = w;
        }
        public override void draw()
        {
            wid.draw();
            Console.WriteLine("------BorderDecorator--------");
          
            
        }
    }

    class ScrollDecorator : Decorator
    {
        

        public ScrollDecorator(Widget w) : base(w)
        {
            wid = w;
        }

        public override void draw()
        {

            wid.draw();
            Console.WriteLine("Scroll decorator!");

            
        }
    }

    class RippleDecorator : Decorator
    {
        

        public RippleDecorator(Widget w) : base(w)
        {
            wid = w;
        }

        public override void draw()
        {

            wid.draw();
            Console.WriteLine("Ripple!");

           
        }
    }
}
