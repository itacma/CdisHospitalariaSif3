using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Collections;

namespace SIFNegocio.Helpers
{
    public class Ticket
    {
        ArrayList headerLines = new ArrayList();
        ArrayList subHeaderLines = new ArrayList();
        ArrayList items = new ArrayList();
        ArrayList totales = new ArrayList();
        ArrayList footerLines = new ArrayList();
        private Image headerImage = null;

        int count = 0;

        int maxChar = 35;
        int maxCharDescription = 20;

        int imageHeight = 0;

        float leftMargin = 0;
        float topMargin = 3;

        string fontName = "Lucida Console";
        int fontSize = 8;

        Font printFont = null;
        SolidBrush myBrush = new SolidBrush(Color.Black);

        Graphics gfx = null;

        string line = null;

        public Ticket()
        {

        }

        public Image HeaderImage
        {
            get { return headerImage; }
            set { if (headerImage != value) headerImage = value; }
        }

        public int MaxChar
        {
            get { return maxChar; }
            set { if (value != maxChar) maxChar = value; }
        }

        public int MaxCharDescription
        {
            get { return maxCharDescription; }
            set { if (value != maxCharDescription) maxCharDescription = value; }
        }

        public int FontSize
        {
            get { return fontSize; }
            set { if (value != fontSize) fontSize = value; }
        }

        public string FontName
        {
            get { return fontName; }
            set { if (value != fontName) fontName = value; }
        }

        public void AddHeaderLine(string line)
        {
            headerLines.Add(line);
        }

        public void AddSubHeaderLine(string line)
        {
            subHeaderLines.Add(line);
        }

        public void AddItem(string cantidad, string item, string price, string import, string description, string porcentajeDescuento = "", string precioSinDescuento = "", string precioConDescuento = "")
        {
            OrderItem newItem = new OrderItem('?');
            items.Add(newItem.GenerateItem(cantidad, item, price, import, description, porcentajeDescuento, precioSinDescuento, precioConDescuento));
        }

        public void AddTotal(string name, string price)
        {
            OrderTotal newTotal = new OrderTotal('?');
            totales.Add(newTotal.GenerateTotal(name, price));
        }

        public void AddFooterLine(string line)
        {
            footerLines.Add(line);
        }

        private string AlignRightText(int lenght)
        {
            string espacios = "";
            int spaces = maxChar - lenght;
            for (int x = 0; x < spaces; x++)
                espacios += " ";
            return espacios;
        }

        private string DottedLine()
        {
            string dotted = "";
            for (int x = 0; x < maxChar; x++)
                dotted += "=";
            return dotted;
        }

        public bool PrinterExists(string impresora)
        {
            foreach (String strPrinter in PrinterSettings.InstalledPrinters)
            {
                if (impresora == strPrinter)
                    return true;
            }
            return false;
        }

        PrintDocument pr = new PrintDocument();
        public void PrintTicket(string impresora)
        {
            printFont = new Font(fontName, fontSize, FontStyle.Regular);

            pr.PrinterSettings.PrinterName = impresora;
            pr.PrintPage += new PrintPageEventHandler(pr_PrintPage);
            pr.Print();
        }       

        public void PrintEtiqueta(string impresora)
        {

            printFont = new Font(fontName, 12, FontStyle.Regular);
            pr.PrinterSettings.PrinterName = impresora;
            pr.PrintPage += new PrintPageEventHandler(pr_PrintPageEtiqueta);
            pr.Print();

        }
        private void pr_PrintPageEtiqueta(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           
            e.HasMorePages = false;
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            gfx = e.Graphics;

            DrawImageCenter();
            DrawHeader();
            DrawSubHeader();
            if (e.HasMorePages)
            {
                return;
            }

            DrawTotales();
            DrawFooter();

            if (headerImage != null)
            {
                HeaderImage.Dispose();
                headerImage.Dispose();
            }
        }
        private void pr_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.HasMorePages = false;
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            gfx = e.Graphics;
            
            DrawImageCenter();
            DrawHeader();
            DrawSubHeader();
            DrawItems(e);
            if (e.HasMorePages)
            {
                return;
            }

            DrawTotales();
            DrawFooter();

            if (headerImage != null)
            {
                HeaderImage.Dispose();
                headerImage.Dispose();
            }
        }

        private float YPosition()
        {
            float val = topMargin + (count * printFont.GetHeight(gfx) + imageHeight);
            return val;
        }

        private void DrawImage()
        {
            if (headerImage != null)
            {
                try
                {
                    gfx.DrawImage(headerImage, new Point((int)leftMargin, (int)YPosition()));
                    double height = ((double)headerImage.Height / 58) * 15;
                    imageHeight = (int)SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(height) + 3;
                }
                catch (Exception)
                {
                }
            }
        }


        private bool imagePrinted = false;
        private void DrawImageCenter()
        {


            if (headerImage != null)
            {
                try
                {
                    RectangleF rectf = gfx.VisibleClipBounds;

                    float cxImage = (maxChar - (headerImage.Width / gfx.DpiX)) / 2;
                    //gfx.DpiX * headerImage.Width / headerImage.HorizontalResolution;
                    //float cyImage = gfx.DpiY * headerImage.Height /
                    //                                   headerImage.VerticalResolution;
                    gfx.DrawImage(headerImage, cxImage,
                                         YPosition());
                    //gfx.DrawImage(headerImage, new Point((int)leftMargin, (int)YPosition()));
                    double height = ((double)headerImage.Height / 58) * 15;
                    imageHeight = (int)SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(height) + 3;
                }
                catch (Exception)
                {

                }
            }

            if (!imagePrinted)
            {
                imagePrinted = true;
                return;
            }
        }

        private void DrawBarCodeCenter()
        {
            if (headerImage != null)
            {
                try
                {
                    RectangleF rectf = gfx.VisibleClipBounds;

                    float cxImage = (maxChar - (headerImage.Width / gfx.DpiX)) / 2;
                    //gfx.DpiX * headerImage.Width / headerImage.HorizontalResolution;
                    //float cyImage = gfx.DpiY * headerImage.Height /
                    //                                   headerImage.VerticalResolution;
                    gfx.DrawImage(headerImage, cxImage,
                                         YPosition());
                    //gfx.DrawImage(headerImage, new Point((int)leftMargin, (int)YPosition()));
                    double height = ((double)headerImage.Height / 58) * 15;
                    imageHeight = (int)SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(height) + 3;
                }
                catch (Exception)
                {
                }
            }
        }

        private bool HeaderPrinted = false;
        private void DrawHeader()
        {
            if (headerPrinted)
            {
                return;
            }

            StringFormat formatCenter = new StringFormat();
            formatCenter.Alignment = StringAlignment.Center;
            foreach (string header in headerLines)
            {
                if (header.Length > maxChar)
                {
                    int currentChar = 0;
                    int headerLenght = header.Length;

                    while (headerLenght > maxChar)
                    {
                        line = header.Substring(currentChar, maxChar);
                        gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                        count++;
                        currentChar += maxChar;
                        headerLenght -= maxChar;
                    }
                    line = header;
                    Rectangle rect = new Rectangle((int)leftMargin, (int)YPosition(), maxChar * 2, (int)printFont.Height);
                    gfx.DrawString(line.Substring(currentChar, line.Length - currentChar), printFont, myBrush, rect, formatCenter);
                    //gfx.DrawString(line.Substring(currentChar, line.Length - currentChar), printFont, myBrush, leftMargin,YPosition(), new StringFormat());
                    count++;
                }
                else
                {
                    line = header;
                    Rectangle rect = new Rectangle((int)leftMargin, (int)YPosition(), maxChar * 2, (int)printFont.Height);

                    gfx.DrawString(line, printFont, myBrush, rect, formatCenter);
                    //gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                    count++;
                }
            }
            DrawEspacio();

            headerPrinted = true;
        }

        bool subHeaderPrinted = false;
        private void DrawSubHeader()
        {
            if (subHeaderPrinted)
            {
                return;
            }

            foreach (string subHeader in subHeaderLines)
            {

                if (subHeader.Length > maxChar)
                {
                    int currentChar = 0;
                    int subHeaderLenght = subHeader.Length;

                    while (subHeaderLenght > maxChar)
                    {
                        line = subHeader;
                        gfx.DrawString(line.Substring(currentChar, maxChar), printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                        count++;
                        currentChar += maxChar;
                        subHeaderLenght -= maxChar;
                    }
                    line = subHeader;
                    gfx.DrawString(line.Substring(currentChar, line.Length - currentChar), printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                    count++;
                }
                else
                {
                    line = subHeader;

                    gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                    count++;

                    //line = DottedLine();

                    //gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                    //count++;
                }
            }
            DrawEspacio();
            subHeaderPrinted = true;
        }


        public bool ConDescuentos = false;
        public bool EsControlado = false;

        ArrayList arr = null;
        bool headerPrinted = false;
        bool headerItemsPrinted = false;

        bool itemsPrinted = false;
        private void DrawItems(System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (itemsPrinted)
            {
                return;
            }

            OrderItem ordIt = new OrderItem('?');
            line = DottedLine();

            if (!headerItemsPrinted)
            {
                if (!EsControlado)
                    gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                DrawEspacio();
                if (EsControlado)
                {
                    gfx.DrawString("CT ARTICULO      DESCRIPCION", printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                }
                else
                {
                    gfx.DrawString("CT DESCRIPCION   FLEMING    IMPORTE", printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                }
                if (ConDescuentos)
                {
                    count++;
                    gfx.DrawString("DESCTO.         PRECIO    PREC.DSC", printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                }
                headerItemsPrinted = true;

                count++;
                DrawEspacio();
            }

            if (arr == null)
            {
                arr = new ArrayList(items);
            }
            else
            {
                if (arr.Count < items.Count)
                {
                    items = new ArrayList( arr);
                }
            }

            foreach (string item in items)
            {

                line = ordIt.GetItemCantidad(item);

                gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                //PRECIO UNITARIO
                line = ordIt.GetItemUnitPrice(item);
                line = AlignRightText(line.Length + 11) + line; //EL MARGEN DERECHO DEL IMPORTE
                gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                //TOTAL
                line = ordIt.GetItemPrice(item);
                line = AlignRightText(line.Length) + line;

                gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                string name = ordIt.GetItemName(item);

                leftMargin = 0;
                if (name.Length > maxCharDescription)
                {
                    int currentChar = 0;
                    int itemLenght = name.Length;

                    while (itemLenght > maxCharDescription)
                    {
                        line = ordIt.GetItemName(item);
                        gfx.DrawString("   " + line.Substring(currentChar, maxCharDescription), printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                        count++;
                        currentChar += maxCharDescription;
                        itemLenght -= maxCharDescription;
                    }

                    line = ordIt.GetItemName(item);
                    gfx.DrawString("   " + line.Substring(currentChar, line.Length - currentChar), printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                    count++;
                }
                else
                {
                    gfx.DrawString("   " + ordIt.GetItemName(item), printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                    count++;
                }

                //ESCRIBIR EL MONTO SIN DESCUENTO, CON DESCUENTO Y EL PORCENTAJE DE DESCUENTO
                if (ConDescuentos)
                {
                    //count++;
                    leftMargin = 0;
                    line = ordIt.GetItemPorcentajeDescuento(item);

                    gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                    //PRECIO UNITARIO
                    line = ordIt.GetItemPrecioSinDescuento(item);
                    line = AlignRightText(line.Length + 11) + line; //EL MARGEN DERECHO DEL IMPORTE
                    gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                    //TOTAL
                    line = ordIt.GetItemPrecioConDescuento(item);
                    line = AlignRightText(line.Length) + line;

                    gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                    count++;
                }
                //TERMINA DESCUENTOS


                string descripcion = ordIt.GetItemDescription(item);
                maxCharDescription = 30;
                if (descripcion.Length > maxCharDescription)
                {
                    int currentChar = 0;
                    int itemLenght = descripcion.Length;

                    while (itemLenght > maxCharDescription)
                    {
                        line = ordIt.GetItemDescription(item);
                        gfx.DrawString("   " + line.Substring(currentChar, maxCharDescription), printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                        count++;
                        currentChar += maxCharDescription;
                        itemLenght -= maxCharDescription;
                    }

                    line = ordIt.GetItemDescription(item);
                    gfx.DrawString("   " + line.Substring(currentChar, line.Length - currentChar), printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                    count++;
                }
                else
                {
                    gfx.DrawString("   " + ordIt.GetItemDescription(item), printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                    count++;
                }

                count++;

                arr.Remove(item);

                if (e.PageBounds.Height < (count * 12))
                {
                    //if (e.HasMorePages)
                    //{
                    count = 0;
                    e.HasMorePages = true;
                    return;
                    //}
                }

            }

            leftMargin = 0;
            DrawEspacio();
            line = DottedLine();

            if (!EsControlado)
                gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

            count++;
            DrawEspacio();
            itemsPrinted = true;
        }

        bool totalesPrinted = false;
        private void DrawTotales()
        {
            if (totalesPrinted)
                return;

            OrderTotal ordTot = new OrderTotal('?');

            foreach (string total in totales)
            {
                line = ordTot.GetTotalCantidad(total);
                line = AlignRightText(line.Length) + line;

                gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                leftMargin = 0;

                line = "      " + ordTot.GetTotalName(total);
                gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                count++;
            }
            leftMargin = 0;
            DrawEspacio();
            DrawEspacio();
            totalesPrinted = true;
        }

        bool footerPrinted = false;
        private void DrawFooter()
        {
            if (footerPrinted)
            {
                return;
            }
            foreach (string footer in footerLines)
            {
                if (footer.Length > maxChar)
                {
                    int currentChar = 0;
                    int footerLenght = footer.Length;

                    while (footerLenght > maxChar)
                    {
                        line = footer;
                        gfx.DrawString(line.Substring(currentChar, maxChar), printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                        count++;
                        currentChar += maxChar;
                        footerLenght -= maxChar;
                    }
                    line = footer;
                    gfx.DrawString(line.Substring(currentChar, line.Length - currentChar), printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                    count++;
                }
                else
                {
                    line = footer;
                    gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                    count++;
                }
            }
            leftMargin = 0;
            DrawEspacio();
            footerPrinted = true;
        }

        private void DrawEspacio()
        {
            line = "";

            gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

            count++;
        }
    }

    public class OrderItem
    {
        char[] delimitador = new char[] { '?' };

        public OrderItem(char delimit)
        {
            delimitador = new char[] { delimit };
        }

        public string GetItemCantidad(string orderItem)
        {
            string[] delimitado = orderItem.Split(delimitador);
            return delimitado[0];
        }


        public string GetItemName(string orderItem)
        {
            string[] delimitado = orderItem.Split(delimitador);
            return delimitado[1];
        }

        public string GetItemPrice(string orderItem)
        {
            string[] delimitado = orderItem.Split(delimitador);
            return delimitado[2];
        }

        public string GenerateItem(string cantidad, string itemName, string price)
        {
            return cantidad + delimitador[0] + itemName + delimitador[0] + price;
        }

        internal object GenerateItem(string cantidad, string item, string price, string import, string description)
        {
            return cantidad + delimitador[0] + item + delimitador[0] + price + delimitador[0] + import + delimitador[0] + description;
        }

        internal object GenerateItem(string cantidad, string item, string price, string import, string description, string porcentajeDescuento, string precioSinDescuento, string precioConDescuento)
        {
            return cantidad + delimitador[0] + item + delimitador[0] + price + delimitador[0] + import + delimitador[0] + description + delimitador[0] + porcentajeDescuento + delimitador[0] + precioSinDescuento + delimitador[0] + precioConDescuento;
        }

        internal string GetItemDescription(string item)
        {
            string[] delimitado = item.Split(delimitador);
            return delimitado[4];
        }

        internal string GetItemUnitPrice(string item)
        {
            string[] delimitado = item.Split(delimitador);
            return delimitado[3];
        }


        //DESCUENTOS
        public string GetItemPorcentajeDescuento(string orderItem)
        {
            string[] delimitado = orderItem.Split(delimitador);
            return delimitado[5];
        }

        public string GetItemPrecioSinDescuento(string orderItem)
        {
            string[] delimitado = orderItem.Split(delimitador);
            return delimitado[6];
        }

        public string GetItemPrecioConDescuento(string orderItem)
        {
            string[] delimitado = orderItem.Split(delimitador);
            return delimitado[7];
        }
    }

    public class OrderTotal
    {
        char[] delimitador = new char[] { '?' };

        public OrderTotal(char delimit)
        {
            delimitador = new char[] { delimit };
        }

        public string GetTotalName(string totalItem)
        {
            string[] delimitado = totalItem.Split(delimitador);
            return delimitado[0];
        }

        public string GetTotalCantidad(string totalItem)
        {
            string[] delimitado = totalItem.Split(delimitador);
            return delimitado[1];
        }

        public string GenerateTotal(string totalName, string price)
        {
            return totalName + delimitador[0] + price;
        }
    }
}