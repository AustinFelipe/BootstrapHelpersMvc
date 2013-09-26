using System;
using System.Collections.Generic;

namespace BootstrapMvc.Base.Utils
{
    public enum GridOptions
    {
        ExtraSmallDevices,
        SmallDevices,
        MediumDevices,
        LargeDevices
    }

    public class GridCol
    {
        public GridOptions GridType { get; set; }
        public int Size { get; set;} 
    }

    public class GridResponsive : List<GridCol>
    {
        public GridResponsive()
        {
            this.Add(new GridCol() { GridType = GridOptions.ExtraSmallDevices, Size = 12 });
            this.Add(new GridCol() { GridType = GridOptions.LargeDevices, Size = 12 });
            this.Add(new GridCol() { GridType = GridOptions.MediumDevices, Size = 12 });
            this.Add(new GridCol() { GridType = GridOptions.SmallDevices, Size = 12 });
        }

        public static GridResponsive GridResponsiveWithoutCol()
        {
            GridResponsive g = new GridResponsive();

            g.Clear();

            return g; 
        }

        public override string ToString()
        {
            string classPrefix = String.Empty;

            foreach (var item in this)
            {
                classPrefix += String.Format(String.IsNullOrEmpty(classPrefix) ? "{0}" : " {0}", 
                    GridUtils.GetClassPrefix(item.GridType, item.Size));
            }

            return classPrefix;
        }
    }

    public static class GridUtils
    {
        /// <summary>
        /// Return a GridResponsive system based on params 
        /// </summary>
        /// <param name="extraSmallSize">Size to extra small devices</param>
        /// <param name="smallSize">Size to small devices</param>
        /// <param name="mediumSize">Size to medium devices</param>
        /// <param name="largeSize">Size to large devices</param>
        /// <returns></returns>
        public static GridResponsive FormatGrid(int extraSmallSize = 0, int smallSize = 0, int mediumSize = 0,
            int largeSize = 0)
        {
            GridResponsive t = GridResponsive.GridResponsiveWithoutCol();

            if (extraSmallSize > 0)
                t.Add(new GridCol() { GridType = GridOptions.ExtraSmallDevices, Size = extraSmallSize });
            if (smallSize > 0)
                t.Add(new GridCol() { GridType = GridOptions.SmallDevices, Size = smallSize });
            if (mediumSize > 0)
                t.Add(new GridCol() { GridType = GridOptions.MediumDevices, Size = mediumSize });
            if (largeSize > 0)
                t.Add(new GridCol() { GridType = GridOptions.LargeDevices, Size = largeSize });
            
            return t;
        }

        public static string GetClassPrefix(GridOptions gridOption, int size)
        {
            string classPrefix = String.Empty;

            switch (gridOption)
            {
                case GridOptions.ExtraSmallDevices:
                    classPrefix = "col-xs";
                    break;
                case GridOptions.SmallDevices:
                    classPrefix = "col-sm";
                    break;
                case GridOptions.MediumDevices:
                    classPrefix = "col-md";
                    break;
                case GridOptions.LargeDevices:
                    classPrefix = "col-lg";
                    break;
                default:
                    break;
            }

            classPrefix = String.Format("{0}-{1}", classPrefix, size);

            return classPrefix;
        }
    }
}
