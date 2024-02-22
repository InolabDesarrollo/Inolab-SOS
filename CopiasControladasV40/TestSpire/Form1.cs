using AutoUpdaterDotNET;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Extgstate;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace TestSpire
{
    public partial class Form1 : MaterialForm
    {
        //****************RUTAS PARA IMAGENES FIRMAS, SELLOS
        public static string PathR = AppContext.BaseDirectory;
        //public string stamp = PathR + @"Rubricas\StampV1.png";
        public string stamp = PathR + @"Rubricas\StampAnexo.png";
        public string OnlyStamp = PathR + @"Rubricas\StampAlone.png";
        public string AnexoStamp = PathR + @"Rubricas\AnexoStamp.png";
        public string StampInges = PathR + @"Rubricas\SelloInges.png";
        public string controlStamp = PathR + @"Rubricas\controlStamp.png";
        public string stampImpresion = PathR + @"Rubricas\StampImpresion.png";
        public string stampResultCliente = PathR + @"Rubricas\StampResultadosCliente.png";

        private Functions ft = new Functions();


        //******************* CREAMOS EL DIALOG PARA SELECCIONAR EL ARCHIVO
        private OpenFileDialog test;
        private string route;


        //***************** DEFINE LA ALTURA EN LA QUE SE COLOCAN LAS FIRMAS DEPENDIENDO DE LA ZONA SELECCIONADA EN POSICION DEL SELLO
        private float SetVertical(System.Windows.Forms.TableLayoutPanel.ControlCollection controls, Rectangle pagesize)
        {
            float r = 20;
            foreach (TextBox tb in controls)
            {
                if (tb.BackColor == System.Drawing.Color.Red)
                {
                    if (!rotar.Checked)
                    {
                        switch (tb.Name)
                        {
                            case "Position1":
                                r = pagesize.GetTop() - 145;
                                break;

                            case "Position2":
                                r = pagesize.GetTop() - 145;
                                break;

                            case "Position3":
                                r = pagesize.GetHeight() / 2;
                                break;

                            case "Position4":
                                r = pagesize.GetHeight() / 2;
                                break;

                            case "Position5":
                                r = pagesize.GetBottom() + 25;
                                break;

                            case "Position6":
                                r = pagesize.GetBottom() + 25;
                                break;

                            default:
                                break;
                        }
                    }
                    else
                    {
                        switch (tb.Name)
                        {
                            case "Position1":
                                r = pagesize.GetBottom() + 45;
                                break;

                            case "Position2":
                                r = pagesize.GetTop() - 145;
                                break;

                            case "Position3":
                                r = pagesize.GetBottom() + 45;
                                break;

                            case "Position4":
                                r = pagesize.GetTop() - 145;
                                break;

                            case "Position5":
                                r = pagesize.GetBottom() + 45;
                                break;

                            case "Position6":
                                r = pagesize.GetTop() - 145;
                                break;

                            default:
                                break;
                        }
                    }
                }
            }
            return r;
        }


        //****************** DEFINE POSICION HORIZONTAL DEL SELLO DEPENDIENDO DE LA ZONA SELECCIONADA POR EL USUARIO 
        private float SetHorizontal(System.Windows.Forms.TableLayoutPanel.ControlCollection controls, Rectangle pagesize)
        {
            float r = pagesize.GetRight() - 100;
            foreach (TextBox tb in controls)
            {
                if (tb.BackColor == System.Drawing.Color.Red)
                {
                    if (!rotar.Checked)
                    {
                        switch (tb.Name)
                        {
                            case "Position1":
                                r = pagesize.GetLeft() + 35;
                                break;

                            case "Position2":
                                r = pagesize.GetRight() - 100;
                                break;

                            case "Position3":
                                r = pagesize.GetLeft() + 35;
                                break;

                            case "Position4":
                                r = pagesize.GetRight() - 100;
                                break;

                            case "Position5":
                                r = pagesize.GetLeft() + 35;
                                break;

                            case "Position6":
                                r = pagesize.GetRight() - 100;
                                break;

                            default:
                                break;
                        }
                    }
                    else
                    {
                        switch (tb.Name)
                        {
                            case "Position1":
                                r = pagesize.GetLeft() + 35;
                                break;

                            case "Position2":
                                r = pagesize.GetLeft() + 35;
                                break;

                            case "Position3":
                                r = pagesize.GetWidth() / 2;
                                break;

                            case "Position4":
                                r = pagesize.GetWidth() / 2;
                                break;

                            case "Position5":
                                r = pagesize.GetRight() - 135;
                                break;

                            case "Position6":
                                r = pagesize.GetRight() - 135;
                                break;

                            default:
                                break;
                        }
                    }
                }
            }
            return r;
        }


        private void StampDataResultados(Document document, PdfDocument pdfDocument, int i, string day, string month, string year)
        {
            // Load image from disk
            iText.IO.Image.ImageData imageData = ImageDataFactory.Create(stampImpresion);
            

            PdfPage page = pdfDocument.GetPage(i);
            int rotate = page.GetRotation();

            Rectangle pageSize;
            PdfCanvas canvas;
            page = pdfDocument.GetPage(i);
            pageSize = page.GetPageSize();
            canvas = new PdfCanvas(page);

            /*Verifica si la rotación de un archivo ya es de 90°(hay archivos que se ven verticales pero
             * en sus propiedades están definidos como horizontales)
             */
            if (rotate == 0 && rotar.Checked)
            {
                page.SetRotation(90);
            }
            else
            {
                //page.setRotation((rotate + 90) % 360);
            }

            // Create layout image object and provide parameters. Page number = 1
            //Tamaño del sello
            float y = 113.3786F;
            float x = 85.034F;

            //Coordenadas del sello
            double xp, yp;
            yp = 20;//VerticalSet of the Stamp
            yp = SetVertical(tableLayoutPanel1.Controls, pageSize);
            xp = SetHorizontal(tableLayoutPanel1.Controls, pageSize);
            //Coordenadas de las letras de la fecha
            double xd = 500, yd = 300;

            //Coordenadas y Tamaño de la rubrica
            double xr = 490, yr = 335, xs = 50, ys = 65;

            //
            ys = ys - 40; xs = xs + 25;
            xr = xp; yr = yp;
            xd = xp + 20; yd = yp - 50;
            
            if (i == 1 && StampMiddle.Checked && rotar.Checked)
            {
                xp = (pageSize.GetWidth()) - 100;
                yp = (pageSize.GetTop() / 2) - 40;
                xd = xp + 20;
                yd = yp + 44;
            }
            else
            if (i == 1 && StampMiddle.Checked && !rotar.Checked)
            {
                if (pageSize.GetHeight() < pageSize.GetWidth())
                {
                    xp = (pageSize.GetWidth() / 2) - 33;
                    yp = pageSize.GetBottom() + 9;
                }
                else
                {
                    xp = (pageSize.GetWidth() / 2) - 40;
                    yp = pageSize.GetBottom() + (imageData.GetHeight() / 4);
                }
            }
            else if (rotar.Checked)
            {
                xr += 90;
            }

            //Definición del color de las letras de la fecha
            Color color = new DeviceRgb(36, 26, 247);
            double angle = 0;
            Image image;
            iText.IO.Image.ImageData DataAnexo;

            //"Impresión" del sello en la página
            image = new Image(imageData).ScaleAbsolute(x, y).SetFixedPosition(i, (float)xp, (float)yp);

            //Rub = new Image(Rubrica).ScaleAbsolute((float)xs, (float)ys).SetFixedPosition(i, (float)xr, (float)yr + 35);
            if (rotar.Checked)
            {
                image.SetProperty(Property.ROTATION_ANGLE, (Math.PI / 180) * 90);
                //Rub.SetFixedPosition(i, (float)xr - 37, (float)yr);
                //Rub.SetProperty(Property.ROTATION_ANGLE, (Math.PI / 180) * 90);
            }
            if (rotate == 180)
            {
                image.SetProperty(Property.ROTATION_ANGLE, (Math.PI / 180) * 180);
                //Rub.SetProperty(Property.ROTATION_ANGLE, (Math.PI / 180) * 180);
            }


            // "impresión del sello sobre la página"
            document.Add(image);

            //Definicion de las letras de la fecha
            Paragraph Day = new Paragraph(day).SetFontSize(8).SetFontColor(color);
            Paragraph Month = new Paragraph(month).SetFontSize(8).SetFontColor(color);
            Paragraph Year = new Paragraph(year).SetFontSize(8).SetFontColor(color);

            Paragraph Num = new Paragraph(txtResultadosN.Text).SetFontSize(8).SetFontColor(color); //numero de resultados;
            Paragraph AnexoP = new Paragraph(AnexoCCAYAC.Text).SetFontSize(9).SetFontColor(color).SetBold(); //numero de anexo;
            Paragraph FolioFSR = new Paragraph(frs.Text).SetFontSize(8).SetFontColor(color);
                  
            canvas.SaveState();
            PdfExtGState gs1 = new PdfExtGState();
            canvas.SetExtGState(gs1);

            //Rutina para dibujar las piezas si se quieren rotar
            if (rotar.Checked) //ROTA 90° EL DOCUMENTO
            {
                angle = (Math.PI / 180) * 90;
                yd = xr - 5.55;
                xd = yr - 17;
                document.ShowTextAligned(Num, (float)yd - 53, (float)xd + 98, pdfDocument.GetPageNumber(page), TextAlignment.RIGHT, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(Day, (float)yd - 33, (float)xd + 40, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(Month, (float)yd - 33, (float)xd + 58, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(Year, (float)yd - 33, (float)xd + 76, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(AnexoP, (float)yd + 7, (float)xd + 78, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(FolioFSR, (float)yd + 25, (float)xd + 58, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
            }
            else if (!rotar.Checked && rotate != 180) //SELLO SIN NUNGUN CHECK EN LAS OPCIONES
            {
                document.ShowTextAligned(Num, (float)xd + 60, (float)yd + 132, pdfDocument.GetPageNumber(page), TextAlignment.RIGHT, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(Day, (float)xd + 2, (float)yd + 112, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(Month, (float)xd + 21, (float)yd + 112, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(Year, (float)xd + 40, (float)yd + 112, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(AnexoP, (float)xd + 41, (float)yd + 72, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(FolioFSR, (float)xd + 21, (float)yd + 54, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
            }
            else if (!rotar.Checked && rotate == 180)
            {
                angle = (Math.PI / 180) * 180;

                document.ShowTextAligned(Num, (float)xd - 11, (float)yd + 10, pdfDocument.GetPageNumber(page), TextAlignment.RIGHT, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(Year, (float)xd + 5, (float)yd + 21, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(Month, (float)xd + 23, (float)yd + 21, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(Day, (float)xd + 43, (float)yd + 21, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(AnexoP, (float)xd + 41, (float)yd + 72, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(FolioFSR, (float)xd + 21, (float)yd + 54, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
            }

            //Datos del sello de anexo CCAYAC
            DataAnexo = ImageDataFactory.Create(stampImpresion); //elige el sello Anexo
            Image image1 = new Image(DataAnexo);
            if (CBCCAYAC.Checked)
            {
                if (Position1.BackColor == System.Drawing.Color.Red)
                {
                    yp = yp - image.GetImageScaledHeight();
                    xd = xd + 40;
                    yd = yd - image.GetImageScaledHeight() + 58;
                    if (rotate == 90)
                    {
                        xd = xd + 17;
                        yd = yd + 47;
                    }
                }
                else if (Position2.BackColor == System.Drawing.Color.Red)
                {
                    xp = xp - 20;
                    yp = yp - image.GetImageScaledHeight();
                    xd = xd + 20;
                    yd = yd - image.GetImageScaledHeight() + 58;
                    if (rotate == 90)
                    {
                        xd = xd + 17;
                        yd = yd + 47;
                    }
                }
                else if (Position3.BackColor == System.Drawing.Color.Red)
                {
                    xp = xp - 20;
                    yp = yp - image.GetImageScaledHeight();
                    xd = xd + 20;
                    yd = yd - image.GetImageScaledHeight() + 58;
                    if (rotate == 90)
                    {
                        xd = xd + 17;
                        yd = yd + 47;
                    }
                }
                else if (Position4.BackColor == System.Drawing.Color.Red)
                {
                    xp = xp - 20;
                    yp = yp - image.GetImageScaledHeight();
                    xd = xd + 20;
                    yd = yd - image.GetImageScaledHeight() + 58;
                    if (rotate == 90)
                    {
                        xd = xd + 17;
                        yd = yd + 47;
                    }
                }
                else if (Position5.BackColor == System.Drawing.Color.Red)
                {
                    xp = xp - 20;
                    yp = yp + image.GetImageScaledHeight() + 10;
                    xd = xd + 20;
                    yd = yd + image.GetImageScaledHeight() + 68;
                    if (rotate == 90)
                    {
                        xd = xd + 17;
                        yd = yd + 47;
                    }
                }
                else if (Position6.BackColor == System.Drawing.Color.Red)
                {
                    xp = xp - 20;
                    yp = yp + image.GetImageScaledHeight() + 10;
                    xd = xd + 20;
                    yd = yd + image.GetImageScaledHeight() + 68;
                    if (rotate == 90)
                    {
                        xd = xd + 17;
                        yd = yd + 47;
                    }
                }

                angle = (Math.PI / 180) * rotate;
                image1.SetProperty(Property.ROTATION_ANGLE, angle);
                image1.ScaleAbsolute(y, x).SetFixedPosition(i, (float)xp, (float)yp);
                Paragraph Anexo = new Paragraph(AnexoCCAYAC.Text).SetFontSize(8).SetFontColor(color);//agrega el texto en el sello del anexo
                document.ShowTextAligned(Anexo, (float)xd, (float)yd, pdfDocument.GetPageNumber(page), TextAlignment.RIGHT, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.Add(image1);
            }
            canvas.RestoreState();
        }


        private void StampDataResultadosCliente(Document document, PdfDocument pdfDocument, int i, string day, string month, string year)
        {
            iText.IO.Image.ImageData imageData = ImageDataFactory.Create(stampResultCliente);


            PdfPage page = pdfDocument.GetPage(i);
            int rotate = page.GetRotation();

            Rectangle pageSize;
            PdfCanvas canvas;
            page = pdfDocument.GetPage(i);
            pageSize = page.GetPageSize();
            canvas = new PdfCanvas(page);

            /*Verifica si la rotación de un archivo ya es de 90°(hay archivos que se ven verticales pero
             * en sus propiedades están definidos como horizontales)
             */
            if (rotate == 0 && rotar.Checked)
            {
                page.SetRotation(90);
            }
            else
            {
                //page.setRotation((rotate + 90) % 360);
            }

            // Create layout image object and provide parameters. Page number = 1
            //Tamaño del sello
            float y = 113.3786F;
            float x = 85.034F;

            //Coordenadas del sello
            double xp, yp;
            yp = 20;//VerticalSet of the Stamp
            yp = SetVertical(tableLayoutPanel1.Controls, pageSize);
            xp = SetHorizontal(tableLayoutPanel1.Controls, pageSize);
            //Coordenadas de las letras de la fecha
            double xd = 500, yd = 300;

            //Coordenadas y Tamaño de la rubrica
            double xr = 490, yr = 335, xs = 50, ys = 65;

            //
            ys = ys - 40; xs = xs + 25;
            xr = xp; yr = yp;
            xd = xp + 20; yd = yp - 50;

            if (i == 1 && StampMiddle.Checked && rotar.Checked)
            {
                xp = (pageSize.GetWidth()) - 100;
                yp = (pageSize.GetTop() / 2) - 40;
                xd = xp + 20;
                yd = yp + 44;
            }
            else
            if (i == 1 && StampMiddle.Checked && !rotar.Checked)
            {
                if (pageSize.GetHeight() < pageSize.GetWidth())
                {
                    xp = (pageSize.GetWidth() / 2) - 33;
                    yp = pageSize.GetBottom() + 9;
                }
                else
                {
                    xp = (pageSize.GetWidth() / 2) - 40;
                    yp = pageSize.GetBottom() + (imageData.GetHeight() / 4);
                }
            }
            else if (rotar.Checked)
            {
                xr += 90;
            }

            //Definición del color de las letras de la fecha
            Color color = new DeviceRgb(36, 26, 247);
            double angle = 0;
            Image image;
            iText.IO.Image.ImageData DataAnexo;

            //"Impresión" del sello en la página
            image = new Image(imageData).ScaleAbsolute(x, y).SetFixedPosition(i, (float)xp, (float)yp);

            //Rub = new Image(Rubrica).ScaleAbsolute((float)xs, (float)ys).SetFixedPosition(i, (float)xr, (float)yr + 35);
            if (rotar.Checked)
            {
                image.SetProperty(Property.ROTATION_ANGLE, (Math.PI / 180) * 90);
                //Rub.SetFixedPosition(i, (float)xr - 37, (float)yr);
                //Rub.SetProperty(Property.ROTATION_ANGLE, (Math.PI / 180) * 90);
            }
            if (rotate == 180)
            {
                image.SetProperty(Property.ROTATION_ANGLE, (Math.PI / 180) * 180);
                //Rub.SetProperty(Property.ROTATION_ANGLE, (Math.PI / 180) * 180);
            }


            // "impresión del sello sobre la página"
            document.Add(image);

            //Definicion de las letras de la fecha
            Paragraph Day = new Paragraph(day).SetFontSize(8).SetFontColor(color);
            Paragraph Month = new Paragraph(month).SetFontSize(8).SetFontColor(color);
            Paragraph Year = new Paragraph(year).SetFontSize(8).SetFontColor(color);

            Paragraph Num = new Paragraph(txtResultadosN.Text).SetFontSize(8).SetFontColor(color); //numero de resultados;
            Paragraph AnexoP = new Paragraph(AnexoCCAYAC.Text).SetFontSize(9).SetFontColor(color).SetBold(); //numero de anexo;
            Paragraph FolioFSR = new Paragraph(frs.Text).SetFontSize(8).SetFontColor(color);

            canvas.SaveState();
            PdfExtGState gs1 = new PdfExtGState();
            canvas.SetExtGState(gs1);

            //Rutina para dibujar las piezas si se quieren rotar
            if (rotar.Checked) //ROTA 90° EL DOCUMENTO
            {
                angle = (Math.PI / 180) * 90;
                yd = xr - 5.55;
                xd = yr - 17;
                document.ShowTextAligned(Num, (float)yd - 50, (float)xd + 90, pdfDocument.GetPageNumber(page), TextAlignment.RIGHT, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(Day, (float)yd - 24, (float)xd + 40, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(Month, (float)yd - 24, (float)xd + 58, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(Year, (float)yd - 24, (float)xd + 76, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(AnexoP, (float)yd , (float)xd + 78, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(FolioFSR, (float)yd + 19, (float)xd + 60, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
            }
            else if (!rotar.Checked && rotate != 180) //SELLO SIN NUNGUN CHECK EN LAS OPCIONES
            {
                document.ShowTextAligned(Num, (float)xd + 55, (float)yd + 129, pdfDocument.GetPageNumber(page), TextAlignment.RIGHT, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(Day, (float)xd + 2, (float)yd + 103, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(Month, (float)xd + 21, (float)yd + 103, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(Year, (float)xd + 40, (float)yd + 103, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(AnexoP, (float)xd + 41, (float)yd + 80, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(FolioFSR, (float)xd + 21, (float)yd + 60, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
            }
            else if (!rotar.Checked && rotate == 180)
            {
                angle = (Math.PI / 180) * 180;

                document.ShowTextAligned(Num, (float)xd - 11, (float)yd + 10, pdfDocument.GetPageNumber(page), TextAlignment.RIGHT, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(Year, (float)xd + 5, (float)yd + 21, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(Month, (float)xd + 23, (float)yd + 21, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(Day, (float)xd + 43, (float)yd + 21, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(AnexoP, (float)xd + 41, (float)yd + 72, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(FolioFSR, (float)xd + 21, (float)yd + 54, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
            }

            //Datos del sello de anexo CCAYAC
            DataAnexo = ImageDataFactory.Create(stampImpresion); //elige el sello Anexo
            Image image1 = new Image(DataAnexo);
            if (CBCCAYAC.Checked)
            {
                if (Position1.BackColor == System.Drawing.Color.Red)
                {
                    yp = yp - image.GetImageScaledHeight();
                    xd = xd + 40;
                    yd = yd - image.GetImageScaledHeight() + 58;
                    if (rotate == 90)
                    {
                        xd = xd + 17;
                        yd = yd + 47;
                    }
                }
                else if (Position2.BackColor == System.Drawing.Color.Red)
                {
                    xp = xp - 20;
                    yp = yp - image.GetImageScaledHeight();
                    xd = xd + 20;
                    yd = yd - image.GetImageScaledHeight() + 58;
                    if (rotate == 90)
                    {
                        xd = xd + 17;
                        yd = yd + 47;
                    }
                }
                else if (Position3.BackColor == System.Drawing.Color.Red)
                {
                    xp = xp - 20;
                    yp = yp - image.GetImageScaledHeight();
                    xd = xd + 20;
                    yd = yd - image.GetImageScaledHeight() + 58;
                    if (rotate == 90)
                    {
                        xd = xd + 17;
                        yd = yd + 47;
                    }
                }
                else if (Position4.BackColor == System.Drawing.Color.Red)
                {
                    xp = xp - 20;
                    yp = yp - image.GetImageScaledHeight();
                    xd = xd + 20;
                    yd = yd - image.GetImageScaledHeight() + 58;
                    if (rotate == 90)
                    {
                        xd = xd + 17;
                        yd = yd + 47;
                    }
                }
                else if (Position5.BackColor == System.Drawing.Color.Red)
                {
                    xp = xp - 20;
                    yp = yp + image.GetImageScaledHeight() + 10;
                    xd = xd + 20;
                    yd = yd + image.GetImageScaledHeight() + 68;
                    if (rotate == 90)
                    {
                        xd = xd + 17;
                        yd = yd + 47;
                    }
                }
                else if (Position6.BackColor == System.Drawing.Color.Red)
                {
                    xp = xp - 20;
                    yp = yp + image.GetImageScaledHeight() + 10;
                    xd = xd + 20;
                    yd = yd + image.GetImageScaledHeight() + 68;
                    if (rotate == 90)
                    {
                        xd = xd + 17;
                        yd = yd + 47;
                    }
                }

                angle = (Math.PI / 180) * rotate;
                image1.SetProperty(Property.ROTATION_ANGLE, angle);
                image1.ScaleAbsolute(y, x).SetFixedPosition(i, (float)xp, (float)yp);
                Paragraph Anexo = new Paragraph(AnexoCCAYAC.Text).SetFontSize(8).SetFontColor(color);//agrega el texto en el sello del anexo
                document.ShowTextAligned(Anexo, (float)xd, (float)yd, pdfDocument.GetPageNumber(page), TextAlignment.RIGHT, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.Add(image1);
            }
            canvas.RestoreState();
        }

        //*********************** FUNCION PARA AGREGAR LOS DATOS SOBRE LAS IMAGENES DEL SELLO
        iText.IO.Image.ImageData Rubrica;
        Image Rub;
        private void StampData(Document document, PdfDocument pdfDocument, int i, string day, string month, string year, string number1)
        {
            // Load image from disk
            iText.IO.Image.ImageData imageData = ImageDataFactory.Create(stamp);            

            PdfPage page = pdfDocument.GetPage(i);
            int rotate = page.GetRotation();

            Rectangle pageSize;
            PdfCanvas canvas;
            page = pdfDocument.GetPage(i);
            pageSize = page.GetPageSize();
            canvas = new PdfCanvas(page);

            /*Verifica si la rotación de un archivo ya es de 90°(hay archivos que se ven verticales pero
             * en sus propiedades están definidos como horizontales)
             */
            if (rotate == 0 && rotar.Checked)
            {
                page.SetRotation(90);
            }
            else
            {
                //page.setRotation((rotate + 90) % 360);
            }

            // Create layout image object and provide parameters. Page number = 1
            //Tamaño del sello
            float y = 113.3786F;
            float x = 85.034F;

            //Coordenadas del sello
            double xp, yp;
            yp = 20;//VerticalSet of the Stamp
            yp = SetVertical(tableLayoutPanel1.Controls, pageSize);
            xp = SetHorizontal(tableLayoutPanel1.Controls, pageSize);
            //Coordenadas de las letras de la fecha
            double xd = 500, yd = 300;

            //Coordenadas y Tamaño de la rubrica
            double xr = 490, yr = 335, xs = 50, ys = 65;
            string[] words = { PathR, @"Rubricas\" };

            //
            ys = ys - 40; xs = xs + 25;
            xr = xp; yr = yp;
            xd = xp + 20; yd = yp - 50;
                     

            //Definicion de la rubrica
           Rubrica = ImageDataFactory.Create(ft.imageToByteArray(Usr.Firma));
            

            if (i == 1 && StampMiddle.Checked && rotar.Checked)
            {
                xp = (pageSize.GetWidth()) - 100;
                yp = (pageSize.GetTop() / 2) - 40;
                xd = xp + 20;
                yd = yp + 44;
            }
            else
            if (i == 1 && StampMiddle.Checked && !rotar.Checked)
            {
                if (pageSize.GetHeight() < pageSize.GetWidth())
                {
                    xp = (pageSize.GetWidth() / 2) - 33;
                    yp = pageSize.GetBottom() + 9;
                }
                else
                {
                    xp = (pageSize.GetWidth() / 2) - 40;
                    yp = pageSize.GetBottom() + (imageData.GetHeight() / 4);
                }
            }
            else if (rotar.Checked)
            {
                xr += 90;
            }

            //Definición del color de las letras de la fecha
            Color color = new DeviceRgb(36, 26, 247);
            double angle = 0;
            Image image;
            iText.IO.Image.ImageData DataAnexo;

            //"Impresión" del sello en la página
            image = new Image(imageData).ScaleAbsolute(x, y).SetFixedPosition(i, (float)xp, (float)yp);


            //Impresión de la rubrica
            Rub = new Image(Rubrica).ScaleAbsolute((float)xs, (float)ys).SetFixedPosition(i, (float)xr, (float)yr + 35);
            if (rotar.Checked)
            {
                image.SetProperty(Property.ROTATION_ANGLE, (Math.PI / 180) * 90);
                Rub.SetFixedPosition(i, (float)xr - 37, (float)yr);
                Rub.SetProperty(Property.ROTATION_ANGLE, (Math.PI / 180) * 90);
            }
            if (rotate == 180)
            {
                image.SetProperty(Property.ROTATION_ANGLE, (Math.PI / 180) * 180);
                Rub.SetProperty(Property.ROTATION_ANGLE, (Math.PI / 180) * 180);
            }



            // "impresión del sello sobre la página"
            document.Add(image);

            //Definicion de las letras de la fecha
            Paragraph Day = new Paragraph(day).SetFontSize(8).SetFontColor(color);
            Paragraph Month = new Paragraph(month).SetFontSize(8).SetFontColor(color);
            Paragraph Year = new Paragraph(year).SetFontSize(8).SetFontColor(color);

            Paragraph Num = new Paragraph(number1).SetFontSize(8).SetFontColor(color); //numero de copia controlada;
            Paragraph AnexoP = new Paragraph(AnexoCCAYAC.Text).SetFontSize(9).SetFontColor(color).SetBold(); //Anexo escrito;
            Paragraph FolioFSR = new Paragraph(frs.Text).SetFontSize(8).SetFontColor(color); ;


            canvas.SaveState();
            PdfExtGState gs1 = new PdfExtGState();
            canvas.SetExtGState(gs1);

            //Rutina para dibujar las piezas si se quieren rotar
            if (rotar.Checked) //ROTA 90° EL DOCUMENTO
            {
                angle = (Math.PI / 180) * 90;
                yd = xr - 5.55;
                xd = yr - 17;
                document.ShowTextAligned(Num, (float)yd - 53, (float)xd + 98, pdfDocument.GetPageNumber(page), TextAlignment.RIGHT, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(Day, (float)yd - 33, (float)xd + 40, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(Month, (float)yd - 33, (float)xd + 58, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(Year, (float)yd - 33, (float)xd + 76, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(AnexoP, (float)yd + 7, (float)xd + 78, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(FolioFSR, (float)yd + 25, (float)xd + 58, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
            }
            else if (!rotar.Checked && rotate != 180) //SELLO SIN NUNGUN CHECK EN LAS OPCIONES
            {
                document.ShowTextAligned(Num, (float)xd + 60, (float)yd + 132, pdfDocument.GetPageNumber(page), TextAlignment.RIGHT, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(Day, (float)xd + 2, (float)yd + 112, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(Month, (float)xd + 21, (float)yd + 112, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(Year, (float)xd + 40, (float)yd + 112, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(AnexoP, (float)xd + 41, (float)yd + 72, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(FolioFSR, (float)xd + 21, (float)yd + 54, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
            }
            else if (!rotar.Checked && rotate == 180)
            {
                angle = (Math.PI / 180) * 180;

                document.ShowTextAligned(Num, (float)xd - 11, (float)yd + 10, pdfDocument.GetPageNumber(page), TextAlignment.RIGHT, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(Year, (float)xd + 5, (float)yd + 21, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(Month, (float)xd + 23, (float)yd + 21, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(Day, (float)xd + 43, (float)yd + 21, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(AnexoP, (float)xd + 41, (float)yd + 72, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(FolioFSR, (float)xd + 21, (float)yd + 54, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
            }

            //"impresión" en el documento de la rubrica sobre el sello
            document.Add(Rub);
            

            //Datos del sello de anexo CCAYAC
            DataAnexo = ImageDataFactory.Create(AnexoStamp); //elige el sello Anexo
            Image image1 = new Image(DataAnexo);
            if (CBCCAYAC.Checked)
            {
                if (Position1.BackColor == System.Drawing.Color.Red)
                {
                    yp = yp - image.GetImageScaledHeight();
                    xd = xd + 40;
                    yd = yd - image.GetImageScaledHeight() + 58;
                    if (rotate == 90)
                    {
                        xd = xd + 17;
                        yd = yd + 47;
                    }
                }
                else if (Position2.BackColor == System.Drawing.Color.Red)
                {
                    xp = xp - 20;
                    yp = yp - image.GetImageScaledHeight();
                    xd = xd + 20;
                    yd = yd - image.GetImageScaledHeight() + 58;
                    if (rotate == 90)
                    {
                        xd = xd + 17;
                        yd = yd + 47;
                    }
                }
                else if (Position3.BackColor == System.Drawing.Color.Red)
                {
                    xp = xp - 20;
                    yp = yp - image.GetImageScaledHeight();
                    xd = xd + 20;
                    yd = yd - image.GetImageScaledHeight() + 58;
                    if (rotate == 90)
                    {
                        xd = xd + 17;
                        yd = yd + 47;
                    }
                }
                else if (Position4.BackColor == System.Drawing.Color.Red)
                {
                    xp = xp - 20;
                    yp = yp - image.GetImageScaledHeight();
                    xd = xd + 20;
                    yd = yd - image.GetImageScaledHeight() + 58;
                    if (rotate == 90)
                    {
                        xd = xd + 17;
                        yd = yd + 47;
                    }
                }
                else if (Position5.BackColor == System.Drawing.Color.Red)
                {
                    xp = xp - 20;
                    yp = yp + image.GetImageScaledHeight() + 10;
                    xd = xd + 20;
                    yd = yd + image.GetImageScaledHeight() + 68;
                    if (rotate == 90)
                    {
                        xd = xd + 17;
                        yd = yd + 47;
                    }
                }
                else if (Position6.BackColor == System.Drawing.Color.Red)
                {
                    xp = xp - 20;
                    yp = yp + image.GetImageScaledHeight() + 10;
                    xd = xd + 20;
                    yd = yd + image.GetImageScaledHeight() + 68;
                    if (rotate == 90)
                    {
                        xd = xd + 17;
                        yd = yd + 47;
                    }
                }

                angle = (Math.PI / 180) * rotate;
                image1.SetProperty(Property.ROTATION_ANGLE, angle);
                image1.ScaleAbsolute(y, x).SetFixedPosition(i, (float)xp, (float)yp);
                Paragraph Anexo = new Paragraph(AnexoCCAYAC.Text).SetFontSize(8).SetFontColor(color);//agrega el texto en el sello del anexo
                document.ShowTextAligned(Anexo, (float)xd, (float)yd, pdfDocument.GetPageNumber(page), TextAlignment.RIGHT, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.Add(image1);
            }
            canvas.RestoreState();
        }
        /*CADA DATO DE LOS SELLOS SE AGRGA POR SEPRADO EN EL DOCUMENTO, DEPENDE LA SELECCION*/


        //********************* COLOCA EL SELLO DE COPIA CONTROLADA CON INFORMACION 
        private void marcarItext71(string opened, string nombre, string day, string month, string year, string number, string name, string dd)
        {
            //Rutina principal de sellado con información(sello de copia controlada)
            Document document = null;
            try
            {
                string path = System.IO.Path.GetFullPath(opened);
                string route = @"C:\Users\Public\Documents\mark.pdf";//Ruta donde se resguardará el documeto sellado
                //Creación del documento en la ruta
                PdfDocument pdfDocument = new PdfDocument(new PdfReader(@path), new PdfWriter(route));
                document = new Document(pdfDocument);

                string number1 = "";
                string hojas = pdfDocument.GetNumberOfPages().ToString();
                DateTime fEmision;
                string idcliente = cliente.SelectedValue.ToString();
                string idservicio = servicio.SelectedValue.ToString();
                DateTime.TryParse(day + " " + month + "" + year, out fEmision);

                //*********** PARA HACER PRUEBAS ESTE ID NO GENERA REGISTROS EN LA BD
                if (chkResultados.Checked || chkResultadosCliente.Checked || Usr.K == 27)
                {
                    number1 = "00027";
                    ft.WFile(number1);//OBTIENE LA FIRMA DE QUIEN REALIZA LA COPIA CONTROLADA
                }                
                else
                {
                    //Obtención de Folio de la BD y guardado de datos en la tabla
                    number1 = ft.SetCopia(number, name, dd, DateTime.Now, hojas, uso.Text, idservicio, idcliente, frs.Text, Usr.K.ToString()).ToString();
                }

                if (chkResultados.Checked)
                {
                    int n = pdfDocument.GetNumberOfPages();
                    for (int i = 1; i <= n; i++)
                    {
                        StampDataResultados(document, pdfDocument, i, day, month, year);
                    }
                    document.Close();
                    Preview pv = new Preview();//Ventana de Previsualización de documentos
                    pv.Route = route;//Asignación de ruta al documento
                    pv.ShowDialog(this);
                }
                else if (chkResultadosCliente.Checked)
                {
                    int n = pdfDocument.GetNumberOfPages();
                    for(int i = 1;  i <= n; i++)
                    {
                        StampDataResultadosCliente(document, pdfDocument, i, day, month, year);
                    }
                    document.Close();
                    Preview pv = new Preview();
                    pv.Route = route;
                    pv.ShowDialog(this);
                }
                else if (number1 != "")
                {
                    int n = pdfDocument.GetNumberOfPages();

                    for (int i = 1; i <= n; i++)
                    {
                        StampData(document, pdfDocument, i, day, month, year, number1);
                    }
                    // Don't forget to close the document.
                    // When you use Document, you should close it rather than PdfDocument instance
                    document.Close();
                    Preview pv = new Preview();//Ventana de Previsualización de documentos
                    pv.Route = route;//Asignación de ruta al documento
                    pv.ShowDialog(this);
                }
            }
            catch (SqlException sqle)
            {
                if (sqle.Number == 2627)
                {
                    MessageBox.Show("El Folio no puede Repetirse.");
                }
                else
                {
                    MessageBox.Show(sqle.Message);
                    MessageBox.Show(sqle.ToString());
                }
                if (document != null)
                {
                    document.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                if (document != null)
                {
                    document.Close();
                }
            }
        }

        private void Stamp(PdfDocument pdfDocument, Document document, int i, string stamp)
        {
            // Load image from disk
            iText.IO.Image.ImageData Stamp = ImageDataFactory.Create(stamp);
            PdfPage page = pdfDocument.GetPage(i);
            int rotate = page.GetRotation();
            Rectangle pageSize;

            page = pdfDocument.GetPage(i);
            pageSize = page.GetPageSize();

            //MessageBox.Show(rotate.ToString());
            if (rotate == 0 && rotar.Checked)
            {
                page.SetRotation(90);
            }
            else
            {
                //page.setRotation((rotate + 90) % 360);
            }

            // Create layout image object and provide parameters. Page number = 1
            float y = 85.03395F;
            float x = 85.034F;
            double xp, yp;
            yp = 10;//VerticalSet of stamp
            yp = SetVertical(tableLayoutPanel1.Controls, pageSize);
            xp = SetHorizontal(tableLayoutPanel1.Controls, pageSize);
            yp = SetVertical(tableLayoutPanel1.Controls, pageSize);
            xp = SetHorizontal(tableLayoutPanel1.Controls, pageSize);
            double xd = 500, yd = 300;
            double xr = 490, yr = 335, xs = 50, ys = 65;
            string[] words = { PathR, @"Rubricas\" };

            ys = ys - 40; xs = xs + 25;
            xr = xp; yr = yp;
            xd = xp + 20; yd = yp - 50;

            if (i == 1 && StampMiddle.Checked && rotar.Checked)
            {
                xp = (pageSize.GetWidth()) - 100;
                yp = (pageSize.GetTop() / 2) - 40;
            }
            else
            if (i == 1 && StampMiddle.Checked && !rotar.Checked)
            {
                if (pageSize.GetHeight() < pageSize.GetWidth())
                {
                    xp = (pageSize.GetWidth() / 2) - 33;
                    yp = pageSize.GetBottom() + 9;
                }
                else
                {
                    xp = (pageSize.GetWidth() / 2) - 40;
                    yp = pageSize.GetBottom() + (Stamp.GetHeight() / 4);
                }
            }

            Color color = new DeviceRgb(36, 26, 247);
            double angle = 0;
            Image image = new Image(Stamp);
            iText.IO.Image.ImageData DataAnexo;

            if (CBCCAYAC.Checked)
            {
                DataAnexo = ImageDataFactory.Create(AnexoStamp);
                y = 113.3786F;
                x = 85.034F;
                //xp = xp;

                if (Position1.BackColor == System.Drawing.Color.Red)
                {
                    if (page.GetRotation() == 90)
                    {
                        xd = xd + 57;
                        yd = yd + 107;
                    }
                    else
                    {
                        xd = xd + 40;
                        yd = yd + 58;
                    }
                }
                else if (Position2.BackColor == System.Drawing.Color.Red)
                {
                    xp = xp - 20;
                    if (page.GetRotation() == 90)
                    {
                        xd = xd + 37;
                        yd = yd + 107;
                    }
                    else
                    {
                        xd = xd + 20;
                        yd = yd + 58;
                    }
                }
                else if (Position3.BackColor == System.Drawing.Color.Red)
                {
                    xp = xp - 20;
                    if (page.GetRotation() == 90)
                    {
                        xd = xd + 37;
                        yd = yd + 107;
                    }
                    else
                    {
                        xd = xd + 20;
                        yd = yd + 58;
                    }
                }
                else if (Position4.BackColor == System.Drawing.Color.Red)
                {
                    xp = xp - 20;
                    if (page.GetRotation() == 90)
                    {
                        xd = xd + 37;
                        yd = yd + 107;
                    }
                    else
                    {
                        xd = xd + 20;
                        yd = yd + 58;
                    }
                }
                else if (Position5.BackColor == System.Drawing.Color.Red)
                {
                    xp = xp - 20;
                    if (page.GetRotation() == 90)
                    {
                        xd = xd + 37;
                        yd = yd + 107;
                    }
                    else
                    {
                        xd = xd + 20;
                        yd = yd + 58;
                    }
                }
                else if (Position6.BackColor == System.Drawing.Color.Red)
                {
                    xp = xp - 20;
                    if (page.GetRotation() == 90)
                    {
                        xd = xd + 37;
                        yd = yd + 107;
                    }
                    else
                    {
                        xd = xd + 20;
                        yd = yd + 58;
                    }
                }
                angle = (Math.PI / 180) * page.GetRotation();
                image.SetProperty(Property.ROTATION_ANGLE, angle);

                image.ScaleAbsolute(y, x).SetFixedPosition(i, (float)xp, (float)yp);
                Paragraph Anexo = new Paragraph(AnexoCCAYAC.Text).SetFontSize(8).SetFontColor(color);
                document.ShowTextAligned(Anexo, (float)xd, (float)yd, pdfDocument.GetPageNumber(page), TextAlignment.RIGHT, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.Add(image);
            }
            else
            {
                image = new Image(Stamp).ScaleAbsolute(x, y).SetFixedPosition(i, (float)xp, (float)yp);
                angle = (Math.PI / 180) * page.GetRotation();
                image.SetProperty(Property.ROTATION_ANGLE, angle);
                if (rotar.Checked)
                {
                    image.SetProperty(Property.ROTATION_ANGLE, (Math.PI / 180) * 90);
                }
                // This adds the image to the page
                document.Add(image);
            }
        }


        //************* CREA O LLAMA LA IMAGEN NECESARIA
        private void Stamp(PdfDocument pdfDocument, Document document, int i, string stamp, int IngName)
        {
            iText.IO.Image.ImageData imageData = ImageDataFactory.Create(stamp); ;
            //if (chkResultados.Checked)
            //{
            //    stamp = stampImpresion;
            //    imageData = ImageDataFactory.Create(stamp);
            //}
            //else
            //{
            //    imageData = ImageDataFactory.Create(stamp);
            //}
            // Load image from disk
            

            PdfPage page = pdfDocument.GetPage(i);
            int rotate = page.GetRotation();

            Rectangle pageSize;

            PdfCanvas canvas;
            page = pdfDocument.GetPage(i);
            pageSize = page.GetPageSize();
            canvas = new PdfCanvas(page);

            if (rotate == 0 && rotar.Checked)
            {
                page.SetRotation(90);
            }
            else
            {
                //page.setRotation((rotate + 90) % 360);
            }

            // Create layout image object and provide parameters. Page number = 1

            float y = 85.03395F;
            float x = 85.034F;
            double xp, yp;
            yp = 20;//VerticalSet of the Stamp
            yp = SetVertical(tableLayoutPanel1.Controls, pageSize);
            xp = SetHorizontal(tableLayoutPanel1.Controls, pageSize);
            double xd = 500, yd = 300;
            double xr = 490, yr = 335, xs = 50, ys = 65;
            string[] words = { PathR, @"Rubricas\" };
            string rub = string.Join("", words);
            //string rub = @"\\192.168.15.134\Public\Firmas\";
            ys = ys - 40; xs = xs + 25;
            xr = xp; yr = yp + 15;
            xd = xp + 19.45; yd = yp - 42.5;

            iText.IO.Image.ImageData Rubrica = ImageDataFactory.Create(ft.imageToByteArray(Usr.FirmaInge));

            if (i == 1 && StampMiddle.Checked && rotar.Checked)
            {
                xp = (pageSize.GetWidth()) - 100;
                yp = (pageSize.GetTop() / 2) - 40;
                xd = xp + 20;
                yd = yp + 44;
            }
            else
            if (i == 1 && StampMiddle.Checked && !rotar.Checked)
            {
                if (pageSize.GetHeight() < pageSize.GetWidth())
                {
                    xp = (pageSize.GetWidth() / 2) - 33;
                    yp = pageSize.GetBottom() + 9;
                }
                else
                {
                    xp = (pageSize.GetWidth() / 2) - 40;
                    yp = pageSize.GetBottom() + (imageData.GetHeight() / 4);
                }
            }
            else if (rotar.Checked)
            {
                xr += 80;
                yr += 16;
            }

            Image image = new Image(imageData).ScaleAbsolute(x, y).SetFixedPosition(i, (float)xp, (float)yp + 15);
            Image Rub = new Image(Rubrica).ScaleAbsolute((float)xs, (float)ys).SetFixedPosition(i, (float)xr, (float)yr); //toma la firma de la BD
            if (rotar.Checked)
            {
                image.SetProperty(Property.ROTATION_ANGLE, (Math.PI / 180) * 90);
                Rub.SetProperty(Property.ROTATION_ANGLE, (Math.PI / 180) * 90);
            }
            if (rotate == 180)
            {
                image.SetProperty(Property.ROTATION_ANGLE, (Math.PI / 180) * 180);
                Rub.SetProperty(Property.ROTATION_ANGLE, (Math.PI / 180) * 180);
            }
            // This adds the image to the page
            document.Add(image);

            Color color = new DeviceRgb(36, 26, 247);
            //Paragraph Nom = new Paragraph(nombre).SetFontSize(8).SetFontColor(color);
            Paragraph Day = new Paragraph(DayTxt.Text).SetFontSize(8).SetFontColor(color);
            Paragraph Month = new Paragraph(MonthTxt.Text).SetFontSize(8).SetFontColor(color);
            Paragraph Year = new Paragraph(YearTxt.Text).SetFontSize(8).SetFontColor(color);
            Paragraph Anexo = new Paragraph(AnexoCCAYAC.Text).SetFontSize(8).SetFontColor(color);
            //number1 when the Folio goes automatic

            canvas.SaveState();
            PdfExtGState gs1 = new PdfExtGState();
            //PdfExtGState gs1 = new PdfExtGState().SetFillOpacity(0.2f);
            canvas.SetExtGState(gs1);
            double angle = 0;

            if (rotar.Checked)
            {
                angle = (Math.PI / 180) * 90;
                yd = xr - 5.55;
                //xd = (xp - (image.GetImageScaledHeight())) - 5.35;
                xd = yr - 17;
                //yd = yp - (image.GetImageScaledWidth()) + 45;

                document.ShowTextAligned(Day, (float)yd + 0, (float)xd + 40, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(Month, (float)yd + 0, (float)xd + 59, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(Year, (float)yd + 0, (float)xd + 78, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
            }
            else if (!rotar.Checked && rotate != 180)
            {
                document.ShowTextAligned(Day, (float)xd + 2, (float)yd + 79, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(Month, (float)xd + 21, (float)yd + 79, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(Year, (float)xd + 40, (float)yd + 79, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
            }
            else if (!rotar.Checked && rotate == 180)
            {
                angle = (Math.PI / 180) * 180;

                document.ShowTextAligned(Year, (float)xd + 5, (float)yd + 21, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(Month, (float)xd + 23, (float)yd + 21, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
                document.ShowTextAligned(Day, (float)xd + 43, (float)yd + 21, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, float.Parse(angle.ToString()));
            }
            document.Add(Rub);
            //document.ShowTextAligned(Nom, 520, 363, pdfDocument.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, 0);
            canvas.RestoreState();
        }


        //*************** COLOCA EL SELLO SIMPLE DENTRO DEL ARCHIVO
        private void SoloMarcar(string opened, bool save)
        {
            //Rutina Principal de sello Simple
            Document document = null;
            try
            {
                string path = System.IO.Path.GetFullPath(opened);
                string route = @"C:\Users\Public\Documents\mark.pdf";

                iText.Kernel.Pdf.PdfDocument pdfDocument = new iText.Kernel.Pdf.PdfDocument(new PdfReader(@path), new PdfWriter(route));

                document = new Document(pdfDocument);

                int n = pdfDocument.GetNumberOfPages();
                string stamp = "";
                //Este If define Qué sello se usará
                if (save)
                {
                    stamp = controlStamp;
                }
                else
                {
                    stamp = OnlyStamp;
                }
                if (CBCCAYAC.Checked)
                {
                    stamp = AnexoStamp;
                }
                string hojas = n.ToString();
                string ingName = NomCB.Text;

                if (Usr.Nombre.Contains("Ivann"))
                {
                    ingName = Usr.Nombre;
                }

                if (append.Checked)
                {
                    stamp = StampInges;
                    ft.WFile(DateTime.Now.ToString() + " " + ingName);
                    for (int i = 1; i <= n; i++)
                    {
                        Stamp(pdfDocument, document, i, stamp, (int)NomCB.SelectedValue);
                    }
                }
                else
                {
                    for (int i = 1; i <= n; i++)
                    {
                        Stamp(pdfDocument, document, i, stamp);
                    }
                }
                if (chkResultados.Checked)
                {
                    stamp = stampImpresion;
                    for (int i = 1; i <= n; i++)
                    {
                        Stamp(pdfDocument, document, i, stamp);
                    }
                }
                if (chkResultadosCliente.Checked)
                {
                    stamp = stampResultCliente;
                    for(int i = 1; i <= n; i++)
                    {
                        Stamp(pdfDocument, document, i, stamp);
                    }
                }

                document.Close();

                //open Preview
                Preview pv = new Preview();
                pv.Route = route;

                pv.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.ToString());
                if (document != null)
                {
                    document.Close();
                }
            }
        }


        //**************** MUESTRA LOS CONTROLES DEPENDIENDO DE ID USUARIO 
        public Form1()
        {
            InitializeComponent();

            //***** 
            version.Text = Usr.K + "." + Usr.Rick + "." + Usr.Joi;
            version.Visible = true;
            if (Usr.K != 22 && Usr.K != 27)
            {
                ControlStamp.Visible = false;
            }
            if (Usr.Joi == 4 || Usr.Joi == 5)
            {
                logout.Visible = false;
            }
            else
            {
                Registrados rg = new Registrados();
                rg.Show();
            }
        }

        public Form1(int k, int rick, int joi)
        {
            InitializeComponent();

            if (Usr.K != 22 && Usr.K != 27)
            {
                ControlStamp.Visible = false;
            }
            if (Usr.Joi == 4 || Usr.Joi == 5)
            {
                logout.Visible = false;
            }
            else
            {
                Registrados rg = new Registrados();
                rg.Show();
            }
        }


        //********************* OPEN FILE PARA SELECCION EL ARCHIVO A SELLAR 
        private void button1_Click(object sender, EventArgs e)
        {
            //Rutina para determinar el comportamiento segun el timpo de sello seleccionado
            openFileDialog1.Multiselect = false;
            openFileDialog1.Filter = ".pdf files (*.pdf)|*.pdf";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (append.Checked)//Append es el sello que habilita las firmas de los ingenieros en los sellos de anexos
                {
                    if (countSelected())
                    {
                        test = openFileDialog1;
                        route = openFileDialog1.FileNames[0];

                        //sello.Enabled = false;
                        SoloMarcar(route, false);

                        //sello.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Selecciona alguna posición para el sello.");
                    }
                }
                else if (!sello.Checked && !ControlStamp.Checked) //agrega el sello simple 
                {
                    test = openFileDialog1;
                    route = openFileDialog1.FileNames[0];
                    panel1.Enabled = true;
                    panel2.Enabled = true;
                    NomCB.Enabled = false;
                    ControlStamp.Enabled = false;
                    append.Enabled = false;
                    CBCCAYAC.Enabled = true;
                    button2.Enabled = true;
                    sello.Enabled = false;
                }
                else if (ControlStamp.Checked && !sello.Checked) //sello de control
                {
                    if (countSelected())
                    {
                        test = openFileDialog1;
                        route = openFileDialog1.FileNames[0];
                        test = openFileDialog1;
                        route = openFileDialog1.FileNames[0];

                        panel1.Enabled = true;
                        panel2.Enabled = true;
                        NomCB.Enabled = false;
                        button2.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Selecciona alguna posición para el sello.");
                    }
                }
                else
                {
                    if (countSelected())
                    {
                        test = openFileDialog1;
                        route = openFileDialog1.FileNames[0];

                        sello.Enabled = false;
                        SoloMarcar(route, false);

                        sello.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Selecciona alguna posición para el sello.");
                    }
                }
            }
            else
            {
            }
        }


        //***************** VERIFICA LOS SECTORES ROJOS PARA DEFINIR COORDENADAS DE SELLOS
        private bool countSelected()
        {
            int countSelected = 0;
            foreach (Control ctr in tableLayoutPanel1.Controls)
            {
                if (ctr is TextBox)
                {
                    if (ctr.BackColor == System.Drawing.Color.Red)
                    {
                        countSelected++; //cuenta areas seleccionadas, cambio de color
                    }
                }
            }
            if (countSelected != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //********************** GUARDA EL ARCHIVO SELLADO
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dd;
                if (
                    ft.IsValid(DayTxt.Text)
                    && ft.IsValid(MonthTxt.Text)
                    && ft.IsValid(YearTxt.Text)
                    && NomCB.SelectedIndex != -1
                    && ft.IsValid(frs.Text) && ft.IsValid(AnexoCCAYAC.Text)
                    ) /*
                    && ft.IsValid(uso.Text)
                    && servicio.SelectedIndex != -1
                    && cliente.SelectedIndex != -1*/
                {
                    string date = DayTxt.Text + " " + MonthTxt.Text + " " + YearTxt.Text;

                    if (DateTime.TryParse(date, out dd))
                    {
                        if (countSelected())
                        {
                            if (ControlStamp.Checked)
                            {
                                SoloMarcar(route, true);
                            }
                            if (CBCCAYAC.Checked && sello.Checked)
                            {
                                //AnexoASSelloSimple
                            }
                            else
                            {
                                marcarItext71(route, Usr.Nombre, DayTxt.Text, MonthTxt.Text, YearTxt.Text, Usr.K.ToString(), openFileDialog1.SafeFileName, ft.Date2(dd));
                                ControlStamp.Enabled = true;
                            }

                            panel1.Enabled = false;
                            sello.Enabled = true;
                            button2.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("Selecciona alguna posición para el sello.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Escriba una Fecha Valida.");
                    }
                }
                else
                {
                    MessageBox.Show("Verifique que los campos no estén vacios.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        //*********************CIERRA LOS FORM ABIERTOS
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (Usr.Joi == 4 || Usr.Joi == 5)
            //{
            //    FormCollection frm = Application.OpenForms;

            //    for (int i = 0; i < frm.Count; i++)
            //    {
            //        if (frm[i].Name == "Consultar")
            //        {
            //            frm[i].Close();
            //        }
            //    }
            //    GC.Collect();
            //}
            //else
            //{
            //    Environment.Exit(0);
            //}
        }


        //********************* CIERRA LA SESION DEL USUARIO VERIFICANDO SI AGREGO ARCHIVO
        private void logout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                DialogResult result;
                string fileName = @"C:\Users\Public\Documents\usr.json";
                result = MessageBox.Show("¿Esta seguro que desea cerrar sesión?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (File.Exists(fileName))
                {
                    
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        File.Delete(fileName);
                        this.Close();

                        //Sesion lg = new Sesion();
                        //System.Windows.Forms.
                    }
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.ToString());
            }
        }

        //************ ASIGNA EL MENSAJE AL SELECIONAR CHECK DE 1RA PAGINA
        private string stampMiddleText = "Solamente se sellará la primera hoja en la parte inferior media y las siguentes páginas tendran el sello en la ubicación habitual";
        //string rotarText = "Se rotarán las páginas 90° a la derecha";

        private void rotar_CheckedChanged(object sender, EventArgs e)
        {
        }

        //******************* MUESTRA EL MENSAJE AL SELECCIONAR EL CHECK DE 1RA PAGINA 
        private void StampMiddle_CheckedChanged(object sender, EventArgs e)
        {
            if (StampMiddle.Checked)
            {
                desc.ForeColor = System.Drawing.Color.Red;
                desc.Text = stampMiddleText;
            }
            else
            {
                desc.Text = "";
            }
        }


        //****************** ACTIVA Y DESACTIVA LAS OPCIONES SI SE SELECCIONA CHECK SELLO SIMPLE
        private void sello_CheckedChanged(object sender, EventArgs e)
        {
            if (sello.Checked)
            {
                StampMiddle.Enabled = true;
                ControlStamp.Enabled = false;
                ControlStamp.Checked = false;
                CBCCAYAC.Enabled = true;
                foreach (Control ctr in panel1.Controls)
                {
                    ctr.Enabled = false;
                }
            }
            else
            {
                StampMiddle.Enabled = false;
                ControlStamp.Enabled = true;
            }
        }


        //***************** 
        private void ControlStamp_CheckedChanged(object sender, EventArgs e)
        {
            if (ControlStamp.Checked)
            {
                DateTime date = DateTime.Now;
                DayTxt.Text = date.Day.ToString();
                MonthTxt.Text = date.Month.ToString();
                YearTxt.Text = date.Year.ToString();

                label4.Text = "Descripción";
                label5.Visible = false;
                servicio.Visible = false;
                label7.Text = "Identificación";
                label6.Text = "Recibe";
                sello.Enabled = false;
                sello.Checked = false;
            }
            else
            {
                label4.Text = "Uso";
                label7.Text = "F.S.R";
                label5.Visible = true;
                servicio.Visible = true;
                label6.Text = "Cliente:";
                sello.Enabled = true;
            }
        }


        //**************** SE ACTIVA AL ABRIR UN ARCHIVO Y CAMBIA EL COLOR DEL PANEL DE POSICION AL SELECCIONARLO
        public void LockUnlock(TextBox tb)
        {
            button1.Focus(); //foco sobre boton Abrir, para seleccionar el documento
            tb.BackColor = System.Drawing.Color.Red;
            foreach (Control ctrl in tableLayoutPanel1.Controls) //activa todos los controles dentro del panel
            {
                if (ctrl is TextBox && ctrl.Name != tb.Name)
                {
                    ctrl.BackColor = System.Drawing.Color.Gray;
                }
            }
        }


        //*************** LLAMA FUNCION PARA BLOQUEAR O DESBLOQUEAR CONTROLES
        private void Position1_Click(object sender, EventArgs e)
        {
            LockUnlock(Position1);
        }

        private void Position2_Click(object sender, EventArgs e)
        {
            LockUnlock(Position2);
        }

        private void Position3_Click(object sender, EventArgs e)
        {
            LockUnlock(Position3);
        }

        private void Position4_Click(object sender, EventArgs e)
        {
            LockUnlock(Position4);
        }

        private void Position5_Click(object sender, EventArgs e)
        {
            LockUnlock(Position5);
        }

        private void Position6_Click(object sender, EventArgs e)
        {
            LockUnlock(Position6);
        }


        //
        private void append_CheckedChanged(object sender, EventArgs e)
        {
            if (append.Checked)
            {
                //FillNomCBWithEng'sNames
                DataSet dsDataFromDB1 = ft.DS(ft.connectionDB, "Select IdUsuario, Nombre+' '+Apellidos as " +
                    "Nombre from Usuarios where IdArea=6 and firma is not null order by nombre asc");
                NomCB.DataSource = dsDataFromDB1.Tables[0];
                NomCB.DisplayMember = "Nombre";
                NomCB.ValueMember = "IdUsuario";
                ControlStamp.Enabled = false;
                sello.Enabled = false;
                panel1.Enabled = true;
                foreach (Control ctr in panel1.Controls)
                {
                    if (ctr is Panel)
                    {
                        ctr.Enabled = true;
                        label2.Visible = true;
                        label2.Text = "Ing.";
                        foreach (Control cont in panel2.Controls)
                        {
                            cont.Enabled = true;
                        }
                    }
                    else
                    {
                        ctr.Visible = false;
                    }
                }
            }
            else
            {
                DataSet dsDataFromDB1 = ft.DS(ft.connectionDB, "Select * from Usuarios;");
                NomCB.DataSource = dsDataFromDB1.Tables[0];
                NomCB.DisplayMember = "Nombre";
                NomCB.ValueMember = "IdUsuario";
                NomCB.SelectedIndex = NomCB.FindStringExact(Usr.Nombre);
                ControlStamp.Enabled = true;
                sello.Enabled = true;
                /*foreach (Control ctr in panel1.Controls)
                {
                    if (ctr.Name != "NomCB")
                    {
                        ctr.Visible = true;
                    }
                    else
                    {
                        label2.Visible = true;
                        label2.Text = "Nombre";
                        ctr.Enabled = false;
                    }
                }*/
                foreach (Control ctr in panel1.Controls)
                {
                    if (ctr is Panel)
                    {
                        label2.Visible = true;
                        label2.Text = "Nombre";
                        ctr.Enabled = false;
                        foreach (Control cont in panel2.Controls)
                        {
                            cont.Enabled = false;
                        }
                    }
                    else
                    {
                        ctr.Visible = true;
                        ctr.Enabled = false;
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet31.Usuarios' Puede moverla o quitarla según sea necesario.
            this.usuariosTableAdapter.Fill(this.browserDataSet31.Usuarios);
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet3.Clientes' Puede moverla o quitarla según sea necesario.
            this.clientesTableAdapter.Fill(this.browserDataSet3.Clientes);
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet3.Tipo_Servicio' Puede moverla o quitarla según sea necesario.
            this.tipo_ServicioTableAdapter.Fill(this.browserDataSet3.Tipo_Servicio);

            NomCB.SelectedIndex = NomCB.FindStringExact(Usr.Nombre);
            //NomCB.SelectedValue=NomCB.f
            string v = Assembly.GetEntryAssembly().GetName().Version.ToString();
            if (Usr.K == 27) //PARA USUARIO DE PRUEBAS 
            {
                version.Text = Usr.K + "." + Usr.Rick + "." + Usr.Joi;
                version.Visible = true;
                DayTxt.Text = "1";
                MonthTxt.Text = "1";
                YearTxt.Text = "1";
                uso.Text = "1";
                frs.Text = "1";
                AnexoCCAYAC.Text = "10";
                cliente.SelectedIndex = 5;
                CBCCAYAC.Checked = true;
            }

            if (v != "0.0.3.6" || Usr.Joi == 5)
            {
                menuStrip1.Visible = true;
            }
            else
            {
                menuStrip1.Visible = false;
            }
        }

        private void servicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            // MessageBox.Show("Index??: "+servicio.SelectedValue);
        }

        private void NomCB_Leave(object sender, EventArgs e)
        {
        }

        private void NomCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (append.Checked)
                {
                    SqlDataReader Sign = ft.GetRead("Select Firma from Usuarios where IdUsuario=" + NomCB.SelectedValue, ft.connectionDB);
                    if (Sign.GetValue(0) is DBNull)
                    {
                    }
                    else
                    {
                        Usr.FirmaInge = ft.byteArrayToImage((byte[])Sign.GetValue(0));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.ToString());
            }
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void patronToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporte rep = new Reporte();
            rep.Report1 = "Eqs";
            rep.Show();
        }

        private void calificaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporte rep = new Reporte();
            rep.Report1 = "Patrones";
            rep.Show();
        }

        private void CBCCAYAC_CheckedChanged(object sender, EventArgs e)
        {
            if (CBCCAYAC.Checked)
            {
                AnexoCCAYAC.Enabled = true;

                StampMiddle.Checked = false;
                StampMiddle.Enabled = false;
                append.Checked = false;
                append.Enabled = false;
            }
            else
            {
                //AnexoCCAYAC.Enabled = false;
                rotar.Enabled = true;
                StampMiddle.Enabled = true;
                append.Enabled = true;
            }
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result;
                string fileName = @"C:\Users\Public\Documents\usr.json";
                result = MessageBox.Show("¿Esta seguro que desea cerrar sesión?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (File.Exists(fileName))
                {

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        File.Delete(fileName);
                        this.Close();

                        //Sesion lg = new Sesion();
                        //System.Windows.Forms.
                    }
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.ToString());
            }
        }

        private void chkResultados_CheckedChanged(object sender, EventArgs e)
        {
            if (chkResultados.Checked)
            {
                lblRN.Visible = true;
                txtResultadosN.Visible = true;
                ControlStamp.Enabled = false;
                sello.Enabled = false;
                append.Enabled = false;
                CBCCAYAC.Enabled = false;
                uso.Visible = false;
                servicio.Visible = false;
                cliente.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;

            }
            else
            {
                lblRN.Visible = false;
                txtResultadosN.Visible = false;
                ControlStamp.Enabled = true;
                sello.Enabled = true;
                append.Enabled = true;
                CBCCAYAC.Enabled = true;
                uso.Visible = true;
                servicio.Visible = true;
                cliente.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
            }
        }

        private void chkResultadosCliente_CheckedChanged(object sender, EventArgs e)
        {
            if (chkResultadosCliente.Checked)
            {
                lblRN.Visible = true;
                txtResultadosN.Visible = true;
                ControlStamp.Enabled = false;
                sello.Enabled = false;
                append.Enabled = false;
                CBCCAYAC.Enabled = false;
                uso.Visible = false;
                servicio.Visible = false;
                cliente.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;

            }
            else
            {
                lblRN.Visible = false;
                txtResultadosN.Visible = false;
                ControlStamp.Enabled = true;
                sello.Enabled = true;
                append.Enabled = true;
                CBCCAYAC.Enabled = true;
                uso.Visible = true;
                servicio.Visible = true;
                cliente.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
            }
        }
    }
}