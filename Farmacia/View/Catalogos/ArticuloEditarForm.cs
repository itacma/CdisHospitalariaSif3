using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace SIF.View.Catalogos
{
    public partial class ArticuloEditarForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        private SIFModelo.Articulo articulo;
        private SIFNegocio.Articulo articuloL;
        private string claveSt=string.Empty ;

        public ArticuloEditarForm()
        {
            InitializeComponent();
        }

        public ArticuloEditarForm(SIFModelo.Articulo articulo)
            : this()
        {
            // TODO: Complete member initialization
            this.articulo = articulo;
            this.CargaConfAntimicrobianos();// Se utiliza para asignarle color a los antimicrobianos JMQC 25/05/2026
            cargaTipoMedicamento();
            cargaImpuestos();
            CargaLaboratorios();
            EstableceArticulo();
            cargaGrupoHomogeneo();
            this.cargaImagen(false, articulo.ARTICULO_ID );
            

        }

        private void actualizarArticulo()
        {

            if (proveedorComboBoxEx.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un proveedor");
                proveedorComboBoxEx.DroppedDown = true;
                return;
            }

            if (IVACompraComboBoxEx.SelectedItem == null)
            {
                MessageBox.Show("Por favor seleccione el tipo de impuesto");
                IVACompraComboBoxEx.DroppedDown = true;
                return;
            }

            articulo.NOMBRE1 = nombreTextBoxX.Text;
            articulo.NOMBRE2 = nombre2TextBoxX.Text;
            articulo.ACTIVO = esVigenteTrueRadioButton.Checked ? SIFModelo.Tipos.SiNo.SI : SIFModelo.Tipos.SiNo.NO;

            articulo.FactorID = "0"; // grupoHomogeneoComboBoxEx.Text.ToString();
            articulo.PROVEEDOR_ID = int.Parse(proveedorComboBoxEx.SelectedValue.ToString());
            articulo.LABORATORIO_ID = int.Parse(fabricanteComboBoxEx.SelectedValue.ToString());

            articulo.U_COMPRA = unidadCompraTextBoxX.Text;
            articulo.U_VENTA = unidadCompraTextBoxX.Text;

            articulo.TIPO_MEDICAMENTO_CVE = tipoMedicamentoLabelX.Text;

            //SIFModelo.TipoMedicamento t2 = tipo2ComboBoxEx.SelectedItem as SIFModelo.TipoMedicamento;
            //SIFModelo.TipoMedicamento t3 = tipo3comboBoxEx.SelectedItem as SIFModelo.TipoMedicamento;
            //SIFModelo.TipoMedicamento t1 = tipo1ComboBoxEx.SelectedItem as SIFModelo.TipoMedicamento;
            //SIFModelo.TipoMedicamento t4 = tipo4comboBoxEx.SelectedItem as SIFModelo.TipoMedicamento;

            //if (!articulo.TIPO_MEDICAMENTO_CVE.Contains(t2.Clave.ToString()))
            //    articulo.TIPO_MEDICAMENTO_CVE += t2.Clave.ToString() + "|";

            //if (!articulo.TIPO_MEDICAMENTO_CVE.Contains(t3.ToString()))
            //    articulo.TIPO_MEDICAMENTO_CVE += t3.Clave.ToString() + "|";

            //if (!articulo.TIPO_MEDICAMENTO_CVE.Contains(t1.ToString()))
            //    articulo.TIPO_MEDICAMENTO_CVE += t1.Clave.ToString() + "|";

            //if (!articulo.TIPO_MEDICAMENTO_CVE.Contains(t4.ToString()))
            //    articulo.TIPO_MEDICAMENTO_CVE += t4.Clave.ToString() + "|";

            //IVA
            precios.IMP_COMPRA = System.Convert.ToInt32(IVACompraComboBoxEx.SelectedValue);
            precios.IMP_VENTA = System.Convert.ToInt32(IVAVentaComboBoxEx.SelectedValue);

            

            //ACTULIZAR LISTA PRECIOS
            //new SIFNegocio.Articulo()
            //
            SIFNegocio.Articulo articuloL = new SIFNegocio.Articulo();
            SIFModelo.Articulo articuloExistente = new SIFNegocio.Articulo().BuscarPorClave(articulo.ARTICULO_ID);
            
            if (articuloExistente == null)
            {
                articulo.LISTA_SUCURSAL_VTA = "1|2|3|4|5|6|7|8|9|10";
                articulo.PAQUETE  = SIFModelo.Tipos.SiNo.NO; 
                articuloL.Nuevo(articulo);
            }
            else
            {
                articuloL.Modificar(articulo);              
            }

            //ACTUALIZAR LA LISTA DE PRECIOS
            if (precios.ARTICULO_ID == null)
            {
                this.precios.ACTIVO = SIFModelo.Tipos.SiNo.SI;
                precios.ARTICULO_ID = articulo.ARTICULO_ID;
                precios.COSTO_PROM = 0;
                precios.COSTO_ULT_COMPRA = 0;
                precios.FECHA_ALTA = DateTime.Now;
                //precios.FECHA_BAJA = null
                //precios.IMP_COMPRA = 0;
                //precios.IMP_VENTA;
                precios.PRECIO_COSTO = 0;
                precios.PRECIO_VENTA = 0;
                precios.PRECIO_VENTA_FARM = 0;
                precios.PRECIO_VENTA_MAX = 0;
                precios.SUCURSAL_ID = Helpers.Sesion.Sucursal.SucursalID;
                SIFNegocio.Articulo.InsertaListaPrecios(precios);
            }
            else
            {
                SIFNegocio.Articulo.ActualizaListaPrecios(precios);
            }


            SIFNegocio.Articulo.LaboratorioID = System.Convert.ToInt32(this.fabricanteComboBoxEx.SelectedValue);
            SIFNegocio.Articulo.ProveedorID = System.Convert.ToInt32(this.proveedorComboBoxEx.SelectedValue);

            SIFNegocio.Articulo.ProveedorID = System.Convert.ToInt32(proveedorComboBoxEx.SelectedValue);

            SIFNegocio.Articulo.Tipo1 = (int)tipo2ComboBoxEx.SelectedValue;
            SIFNegocio.Articulo.Tipo2 = (int)tipo3comboBoxEx.SelectedValue;
            SIFNegocio.Articulo.Tipo3 = (int)tipo1ComboBoxEx.SelectedValue;
            SIFNegocio.Articulo.Tipo4 = (int)tipo4comboBoxEx.SelectedValue;
            SIFNegocio.Articulo.Tipo7 = (int)tipo7ComboBoxEx.SelectedValue;


            //articulo mayorista
            SIFModelo.OrdenCompra.InfromacionMayorista mayorista = new SIFModelo.OrdenCompra.InfromacionMayorista();
            SIFNegocio.OrdenCompra.InformacionMayorista ofL = new SIFNegocio.OrdenCompra.InformacionMayorista();

            mayorista = ofL.InformacionMayoristaPorArticulo(articulo);
            if (mayorista == null)
            {
                mayorista = new SIFModelo.OrdenCompra.InfromacionMayorista();
            }

            //TIPO DE MEDICAMENTO
            if (this.mayoristaRadioButton.Checked)
            {
                mayorista.COMPRA_CON_MAYORISTA = SIFModelo.Tipos.ComprarConMayorista.MAYORISTA;
            }
            if (this.directoRadioButton.Checked)
            {
                mayorista.COMPRA_CON_MAYORISTA = SIFModelo.Tipos.ComprarConMayorista.DIRECTO;
            }
            if (this.otroRadioButton.Checked)
            {
                mayorista.COMPRA_CON_MAYORISTA = SIFModelo.Tipos.ComprarConMayorista.OTRO;
            }

            mayorista.ARTICULO_ID = articulo.ARTICULO_ID;
            mayorista.PROVEEDOR_ID = 0;
            mayorista.CODIGO_NADRO = "";
            mayorista.CODIGO_DROGUEROS = "";
            mayorista.CODIGO_SABA = "";

            mayorista.DESCUENTO_NADRO = 0;
            mayorista.DESCUENTO_DROGUEROS = 0;
            mayorista.DESCUENTO_SABA = 0;

            mayorista.DESCTO_ADICIONAL_NADRO = 0;
            mayorista.DESCTO_ADICIONAL_DROGUEROS = 0;
            mayorista.DESCTO_ADICIONAL_SABA = 0;

            mayorista.EDO_COMPRA_NADRO = (SIFModelo.Tipos.TipoStatusMayorista.COMPRA);
            mayorista.EDO_COMPRA_DROGUEROS = (SIFModelo.Tipos.TipoStatusMayorista.COMPRA);
            mayorista.EDO_COMPRA_SABA = (SIFModelo.Tipos.TipoStatusMayorista.COMPRA);

            mayorista.TIPO1 = (int)tipo1ComboBoxEx.SelectedValue;
            mayorista.TIPO2 = (int)tipo2ComboBoxEx.SelectedValue;
            mayorista.TIPO3 = (int)tipo3comboBoxEx.SelectedValue;
            mayorista.TIPO4 = (int)tipo4comboBoxEx.SelectedValue;
            mayorista.tipo7 = (int)tipo7ComboBoxEx.SelectedValue;   //jmqc 03/04/2024 cambio para el tipo7
            mayorista.tipo6 = (int)tipo6ComboBoxEx.SelectedValue; //JMQC 23/07/2019 se agrega el tipo6
            
            if (string.IsNullOrEmpty(ListaTipoMedicamentoForm.clavesat))                //JMQC 15/11/2017: Cambios Sat
                mayorista.STATUS = this.tipo5ComboBoxEx.Text.Substring(0, 8);
            else
                mayorista.STATUS = ListaTipoMedicamentoForm.clavesat;                    
            
            mayorista.PERIODO_COMPRA_INICIO = null;
            mayorista.PERIODO_COMPRA_FIN = null;
            mayorista.PROVEEDOR_ID = int.Parse(proveedorComboBoxEx.SelectedValue.ToString()); ;
           // mayorista.comprador_id =  ;
            mayorista.PORCENTAJE_IESPS = (float)((SIFModelo.Impuesto)iepsComboBoxEx.SelectedItem).Porcentaje;
            mayorista.PORCENTAJE_IVA = (float)((SIFModelo.Impuesto)IVACompraComboBoxEx.SelectedItem).Porcentaje;

            if (ColorAntiMicroComboBoxEx.SelectedValue != null)
            {
                // 1. Casteamos el valor al tipo Color
                System.Drawing.Color colorSeleccionado = (System.Drawing.Color)ColorAntiMicroComboBoxEx.SelectedValue;

                // 2. Extraemos los bytes
                byte r = colorSeleccionado.R;
                byte g = colorSeleccionado.G;
                byte b = colorSeleccionado.B;

                // 3. Convertimos a texto con formato "R,G,B"
                mayorista.colorRGB = $"{r},{g},{b}";

                // Ya puedes usar la variable 'rgbTexto' (guardarla en BD, mostrarla en un Label, etc.)
                // Ejemplo: MessageBox.Show(rgbTexto); 
            }
            mayorista.alertaAlComprar = (chkAlertaCmp.Checked)?1:0;// para notificar alerta al escanear un producto en la orden de compra


            if (ofL.GuardaInformacionMayorista(mayorista))
                MessageBox.Show("Se actualizó correctamente el artículo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Error al actualizar el artículo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //termina informacion mayorista

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        SIFModelo.Inventarios.ListaPrecios precios;
        private void cargaImpuestos()
        {

            List<SIFModelo.Impuesto> impuestos = new SIFNegocio.Impuestos().Buscar("", "").DataSource as List<SIFModelo.Impuesto>;

            List<SIFModelo.Impuesto> impuestosCompras = new SIFNegocio.Impuestos().Buscar("", "").DataSource as List<SIFModelo.Impuesto>;

            List<SIFModelo.Impuesto> impuestosVentas = new SIFNegocio.Impuestos().Buscar("", "").DataSource as List<SIFModelo.Impuesto>;

            List<SIFModelo.Impuesto> impuestosIESP = new SIFNegocio.Impuestos().Buscar("", "IEPS").DataSource as List<SIFModelo.Impuesto>;

            this.IVACompraComboBoxEx.DataSource = impuestosCompras;
            this.IVAVentaComboBoxEx.DataSource = impuestosVentas;
            this.iepsComboBoxEx.DataSource = impuestosIESP;

            precios = new SIFNegocio.Articulo().ArticuloPrecio(articulo.ARTICULO_ID);

            if (precios == null)
            {
                precios = new SIFModelo.Inventarios.ListaPrecios();
            }

            IVACompraComboBoxEx.DisplayMember = "Nombre";
            IVACompraComboBoxEx.ValueMember = "ID";
            IVAVentaComboBoxEx.DisplayMember = "Nombre";
            IVAVentaComboBoxEx.ValueMember = "ID";
            iepsComboBoxEx.DisplayMember = "Nombre";
            iepsComboBoxEx.ValueMember = "ID";

            IVACompraComboBoxEx.SelectedValue = precios.IMP_COMPRA;
            IVAVentaComboBoxEx.SelectedValue = precios.IMP_VENTA;
        }

        SIFNegocio.Inventario.EOQ eoqL = new SIFNegocio.Inventario.EOQ();
        private void cargaGrupoHomogeneo()
        {
            grupoHomogeneoComboBoxEx.DataSource = eoqL.FactorEoQ();
            grupoHomogeneoComboBoxEx.DisplayMember = "Tipo";
            grupoHomogeneoComboBoxEx.ValueMember = "Tipo";

            SIFModelo.Articulo artFactor = new SIFNegocio.Articulo().BuscarPorClave(articulo.ARTICULO_ID);

            if (artFactor != null)
            {
                string Factor = artFactor.FactorID;
                grupoHomogeneoComboBoxEx.SelectedValue = Factor;
            }
        }

        private void tipoMedicamento()
        {
            Catalogos.ListaTipoMedicamentoForm tipoMedicamentoForm = new ListaTipoMedicamentoForm(articulo);
            if (tipoMedicamentoForm.ShowDialog() == DialogResult.OK)
            {
                articulo.TIPO_MEDICAMENTO_CVE = tipoMedicamentoForm.ListaTipoMedicamento;
                this.tipoMedicamentoLabelX.Text = articulo.TIPO_MEDICAMENTO_CVE;
            }
        }

        private void CargaLaboratorios()
        {
            SIFNegocio.Clientes clientesL = new SIFNegocio.Clientes();
            if (SIFNegocio.Clientes.LaboratoriosList.Count == 0)
            {
                SIFNegocio.Clientes.LaboratoriosList = clientesL.Laboratorios("");
            }
            List<SIFModelo.Cliente> clientes = SIFNegocio.Clientes.LaboratoriosList;

            foreach (SIFModelo.Cliente cliente in clientes)
            {
                cliente.Nombre = cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno + " - " + cliente.ID;
            }

            this.fabricanteComboBoxEx.DataSource = clientes;
            fabricanteComboBoxEx.DisplayMember = "Nombre";
            fabricanteComboBoxEx.ValueMember = "ID";



            fabricanteComboBoxEx.SelectedValue = articulo.LABORATORIO_ID;

            //PROVEEDOR
            if (SIFNegocio.Clientes.ProveedoresList.Count == 0)
            {
                SIFNegocio.Clientes.ProveedoresList = clientesL.BuscarProveedores("", "").DataSource as List<SIFModelo.Cliente>;
            }

            List<SIFModelo.Cliente> proveedores = SIFNegocio.Clientes.ProveedoresList;

            foreach (SIFModelo.Cliente cliente in proveedores)
            {
                cliente.Nombre = cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno + " - " + cliente.ID;
            }

            this.proveedorComboBoxEx.DataSource = proveedores;
            proveedorComboBoxEx.DisplayMember = "Nombre";
            proveedorComboBoxEx.ValueMember = "ID";



            proveedorComboBoxEx.SelectedValue = articulo.PROVEEDOR_ID;
        }

        private void cargaTipoMedicamento()
        {
            this.tipoMedicamentoLabelX.Text = articulo.TIPO_MEDICAMENTO_CVE;

            List<SIFModelo.TipoMedicamento> tipos = new SIFNegocio.TipoMedicamento().Buscar("", "").DataSource as List<SIFModelo.TipoMedicamento>;
            List<SIFModelo.Tipos.tipo6> tipo6 = new SIFNegocio.TipoMedicamento().BuscarTipo6("%").DataSource as List<SIFModelo.Tipos.tipo6>;// solicitud de precios para tipo 6 23/07/2019 JMQC
            List<SIFModelo.TipoMedicamento> tipo1 = new List<SIFModelo.TipoMedicamento>();
            List<SIFModelo.TipoMedicamento> tipo2 = new List<SIFModelo.TipoMedicamento>();
            List<SIFModelo.TipoMedicamento> tipo3 = new List<SIFModelo.TipoMedicamento>();
            List<SIFModelo.TipoMedicamento> tipo4 = new List<SIFModelo.TipoMedicamento>();
            List<SIFModelo.TipoMedicamento> tipo7 = new List<SIFModelo.TipoMedicamento>();//GENERICO O PATENTE

            var vTipo1 = new SIFNegocio.TipoMedicamento().Tipos(1);
            foreach (SIFModelo.TipoMedicamento tipo in vTipo1)
            {
                //tipo.Nombre = tipo.Clave + " - " + tipo.Nombre;
                tipo1.Add(tipo);
            }

            var vTipo2 = new SIFNegocio.TipoMedicamento().Tipos(2);
            foreach (SIFModelo.TipoMedicamento tipo in vTipo2)
            {
                //tipo.Nombre = tipo.Clave + " - " + tipo.Nombre;
                tipo2.Add(tipo);
            }

            var vTipo3 = new SIFNegocio.TipoMedicamento().Tipos(3);
            foreach (SIFModelo.TipoMedicamento tipo in vTipo3)
            {
                //tipo.Nombre = tipo.Clave + " - " + tipo.Nombre;
                tipo3.Add(tipo);
            }

            var vTipo4 = new SIFNegocio.TipoMedicamento().Tipos(4);
            foreach (SIFModelo.TipoMedicamento tipo in vTipo4)
            {
                //tipo.Nombre = tipo.Clave + " - " + tipo.Nombre;
                tipo4.Add(tipo);
            }


            var vTipo7 = new SIFNegocio.TipoMedicamento().Tipos(7);
            foreach (SIFModelo.TipoMedicamento tipo in vTipo7)
            {
                //tipo.Nombre = tipo.Clave + " - " + tipo.Nombre;
                tipo7.Add(tipo);
            }

            this.tipo1ComboBoxEx.DataSource = tipo1;
            this.tipo2ComboBoxEx.DataSource = tipo2;
            this.tipo3comboBoxEx.DataSource = tipo3;
            this.tipo4comboBoxEx.DataSource = tipo4;
            this.tipo6ComboBoxEx.DataSource = tipo6;
            this.tipo7ComboBoxEx.DataSource = tipo7;

            tipo2ComboBoxEx.DisplayMember = "Nombre";
            tipo2ComboBoxEx.ValueMember = "ID";

            tipo3comboBoxEx.DisplayMember = "Nombre";
            tipo3comboBoxEx.ValueMember = "ID";

            tipo4comboBoxEx.DisplayMember = "Nombre";
            tipo4comboBoxEx.ValueMember = "ID";

            tipo6ComboBoxEx.DisplayMember = "Nombre";
            tipo6ComboBoxEx.ValueMember = "ID";

            tipo1ComboBoxEx.DisplayMember = "Nombre";
            tipo1ComboBoxEx.ValueMember = "ID";

            tipo7ComboBoxEx.DisplayMember = "Nombre";
            tipo7ComboBoxEx.ValueMember = "ID";

            SIFModelo.OrdenCompra.InfromacionMayorista mayorista = new SIFModelo.OrdenCompra.InfromacionMayorista();
            SIFNegocio.OrdenCompra.InformacionMayorista ofL = new SIFNegocio.OrdenCompra.InformacionMayorista();

            mayorista = ofL.InformacionMayoristaPorArticulo(articulo);
            if (mayorista != null)
            {
                tipo1ComboBoxEx.SelectedValue = mayorista.TIPO1;
                tipo2ComboBoxEx.SelectedValue = mayorista.TIPO2;
                tipo3comboBoxEx.SelectedValue = mayorista.TIPO3;
                tipo4comboBoxEx.SelectedValue = mayorista.TIPO4;
                tipo6ComboBoxEx.SelectedValue = mayorista.tipo6;
                tipo7ComboBoxEx.SelectedValue = mayorista.tipo7;

                Console.WriteLine("tipo7 => " + mayorista.tipo7);

                if (!string.IsNullOrEmpty(mayorista.STATUS.ToString()))
                    {//JMQC 15/11/2017: Cambios Sat
                    tipo5ComboBoxEx.Text = mayorista.STATUS;
                    claveSt = mayorista.STATUS;
                    }
                
            }

            //string[] tiposMedicamentos = articulo.TIPO_MEDICAMENTO_CVE.Split(new char[] { '|' });

            //var tipoIEncontrado = from s in tiposMedicamentos where s.StartsWith("S") select s;
            //if (tipoIEncontrado.Count() > 0)
            //{
            //    var tipoIitem = from t in ((ComboBox.ObjectCollection)tipo2ComboBoxEx.Items).OfType<SIFModelo.TipoMedicamento>() where t.Clave == tipoIEncontrado.FirstOrDefault() select t;
            //    if (tipoIitem.Count() > 0)
            //        tipo2ComboBoxEx.SelectedValue = tipoIitem.FirstOrDefault().ID;
            //}

            //var tipoIIEncontrado = from s in tiposMedicamentos where s.StartsWith("U") select s;
            //if (tipoIIEncontrado.Count() > 0)
            //{
            //    var tipoIIitem = from t in ((ComboBox.ObjectCollection)tipo3comboBoxEx.Items).OfType<SIFModelo.TipoMedicamento>() where t.Clave == tipoIIEncontrado.FirstOrDefault() select t;
            //    if (tipoIIitem.Count() > 0)
            //        tipo3comboBoxEx.SelectedValue = tipoIIitem.FirstOrDefault().ID;
            //}

            //var tipoIIIEncontrado = from s in tiposMedicamentos where s.StartsWith("T") select s;
            //if (tipoIIIEncontrado.Count() > 0)
            //{
            //    var tipoIIIitem = from t in ((ComboBox.ObjectCollection)tipo1ComboBoxEx.Items).OfType<SIFModelo.TipoMedicamento>() where t.Clave == tipoIIIEncontrado.FirstOrDefault() select t;
            //    if (tipoIIIitem.Count() > 0)
            //        tipo1ComboBoxEx.SelectedValue = tipoIIIitem.FirstOrDefault().ID;
            //}
        }

        private void EstableceArticulo()
        {
            claveLabelX.Text = articulo.ARTICULO_ID;
            this.nombreTextBoxX.Text = articulo.NOMBRE1;
            this.nombre2TextBoxX.Text = articulo.NOMBRE2;
            unidadCompraTextBoxX.Text = articulo.U_COMPRA;
            unidadVentaTextBoxX.Text = articulo.U_VENTA;

            if (articulo.ACTIVO == SIFModelo.Tipos.SiNo.SI)
            {
                esVigenteTrueRadioButton.Checked = true;
            }
            else
            {
                esVigenteFalseRadioButton.Checked = true;
            }

            var listaPrecios = new SIFNegocio.Articulo().ArticuloPrecio(articulo.ARTICULO_ID);
            if (listaPrecios == null)
            {
                listaPrecios = new SIFModelo.Inventarios.ListaPrecios();
            }

            this.IVACompraComboBoxEx.SelectedValue = listaPrecios.IMP_COMPRA;
            this.IVAVentaComboBoxEx.SelectedValue = listaPrecios.IMP_VENTA;

            this.lineaTextBoxX.Text = articulo.LABORATORIO_ID.ToString();

            fabricanteComboBoxEx.SelectedValue = articulo.LABORATORIO_ID;

            SIFNegocio.OrdenCompra.InformacionMayorista imL = new SIFNegocio.OrdenCompra.InformacionMayorista();
            SIFModelo.OrdenCompra.InfromacionMayorista mayorista = imL.InformacionMayoristaPorArticulo(articulo);

            if (mayorista == null)
            {
                this.directoRadioButton.Checked = true;
            }

            else
            {
                if (mayorista.COMPRA_CON_MAYORISTA == SIFModelo.Tipos.ComprarConMayorista.MAYORISTA)
                {
                    mayoristaRadioButton.Checked = true;
                }

                if (mayorista.COMPRA_CON_MAYORISTA == SIFModelo.Tipos.ComprarConMayorista.DIRECTO)
                {
                    directoRadioButton.Checked = true;
                }

                if (mayorista.COMPRA_CON_MAYORISTA == SIFModelo.Tipos.ComprarConMayorista.OTRO)
                {
                    otroRadioButton.Checked = true;
                }

                List<SIFModelo.Impuesto> it = iepsComboBoxEx.DataSource as List<SIFModelo.Impuesto>;
                var iep = from i in it where i.Porcentaje == (decimal)mayorista.PORCENTAJE_IESPS select i;
                if (iep.Count() > 0)
                {
                    iepsComboBoxEx.SelectedValue = iep.First().ID;
                }

                seleccionaColorG(mayorista.colorRGB);
                chkAlertaCmp.Checked = (mayorista.alertaAlComprar == 0) ? false : true;
                     

            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void fabricanteComboBoxEx_SelectedValueChanged(object sender, EventArgs e)
        {
            if (fabricanteComboBoxEx.SelectedValue != null)
                lineaTextBoxX.Text = fabricanteComboBoxEx.SelectedValue.ToString();
        }

        private void labelX3_Click(object sender, EventArgs e)
        {

        }

        private void tipoMedicamentoButtonX_Click(object sender, EventArgs e)
        {
            tipoMedicamento();
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            actualizarArticulo();
        }

        private void ArticuloEditarForm_Load(object sender, EventArgs e)
        {

            if (articulo.NOMBRE1 == "NOMBRE")
            {
                if (SIFNegocio.Articulo.LaboratorioID != 0)
                {
                    this.lineaTextBoxX.Text = SIFNegocio.Articulo.LaboratorioID.ToString();
                    this.fabricanteComboBoxEx.SelectedValue = SIFNegocio.Articulo.LaboratorioID;

                }

                //{
                this.proveedorComboBoxEx.SelectedValue = SIFNegocio.Articulo.ProveedorID;

                //}

                //if (SIFNegocio.Articulo.Tipo1 != 0)
                //{
                //    tipo2ComboBoxEx.SelectedIndex = SIFNegocio.Articulo.Tipo1;
                //}

                //if (SIFNegocio.Articulo.Tipo2 != 0)
                //{
                //    tipo3comboBoxEx.SelectedIndex = SIFNegocio.Articulo.Tipo2;
                //}
                //if (SIFNegocio.Articulo.Tipo3 != 0)
                //{
                //    tipo1ComboBoxEx.SelectedIndex = SIFNegocio.Articulo.Tipo3;
                //}

            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnXComprador_Click(object sender, EventArgs e)
        {
            Catalogos.frmCompradores tipoMedicamentoForm = new frmCompradores(articulo.PROVEEDOR_ID.ToString(), articulo.ARTICULO_ID);
            if (tipoMedicamentoForm.ShowDialog() == DialogResult.OK)
            {
                //articulo.TIPO_MEDICAMENTO_CVE = tipoMedicamentoForm.ListaTipoMedicamento;
               // this.tipoMedicamentoLabelX.Text = articulo.TIPO_MEDICAMENTO_CVE;
            }
        }


        #region Cabios Sat 
        SIFNegocio.Extras.Parametros param = new SIFNegocio.Extras.Parametros();
        SIFModelo.CatClavesSat Msni = new SIFModelo.CatClavesSat();
        SIFNegocio.Impuestos sni = new SIFNegocio.Impuestos();
        int cfdi33 = 0;
        private bool bandera1;//Permitira no hacer una doble busqueda  al cambiar el valor de combo tipo5

        private void getTipoSatButtonX_Click(object sender, EventArgs e)
            {
            Cursor.Current = Cursors.WaitCursor;
            getTipoSat();
            Cursor.Current = Cursors.Default;
            }

        private void getTipoSat() 
            {
            List<SIFModelo.CatClavesSat> tipoSat = new SIFNegocio.TipoMedicamento().tipoSat().DataSource as List<SIFModelo.CatClavesSat>;
            this.tipo5ComboBoxEx.DataSource = tipoSat;
            tipo5ComboBoxEx.DisplayMember = "descripcion";
            tipo5ComboBoxEx.ValueMember = "clave";
            tipo5ComboBoxEx.SelectedValue = claveSt;
            if (String.IsNullOrEmpty(tipo5ComboBoxEx.Text))
                tipo5ComboBoxEx.SelectedIndex = 1;
                

            }
        private Boolean buscarClaveSat()
            {
            cfdi33 = param.ObtenParametro("CFDI3.3");
            //cfdi33 = 1;
            if (this.tipo5ComboBoxEx.Text.Length < 8 && cfdi33 > 0)
                {
                MessageBox.Show("La calve sat debe de ser minimo de 8 digitos ", "Clave Sat" + Msni.clave, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
                }
            Msni = sni.buscarClaveSat(this.tipo5ComboBoxEx.Text.Substring(0,8));
            if (!String.IsNullOrEmpty(Msni.clave))
                return true;
            else
                {
                if (cfdi33 <= 0)
                    {
                    return true;
                    }
                MessageBox.Show("No existe la clave dentro del catalogo Sat ", "Clave Sat" + Msni.clave, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
                }
            }

        private void tipo5ComboBoxEx_KeyDown(object sender, KeyEventArgs e)
            {
            
            if (e.KeyCode == Keys.Enter)
               {
               
                   if (!this.buscarClaveSat())
                       {
                       return;
                       }
                   else
                       {
                       if (tipo5ComboBoxEx.Text.Length<9)
                       MessageBox.Show(Msni.clave + "-" + Msni.Descripcion, "Clave Sat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       string cadenaTipo =tipoMedicamentoLabelX.Text;
                       string tipo5 ="ST"+ Msni.clave.ToString();
                       string path = "[A-Z]{2}[0-9]{8}";
                       string newStr;
                       Boolean existe = false;


                       Regex rgx = new Regex(path);
                       existe = rgx.IsMatch(cadenaTipo);
                       if (existe)
                           {
                           newStr = rgx.Replace(cadenaTipo, tipo5);
                           tipoMedicamentoLabelX.Text = newStr;
                           }
                       else
                           {
                           tipoMedicamentoLabelX.Text += tipo5 + "|";
                           }

                   
                       }
                 }
            }


        private void tipo5ComboBoxEx_SelectedIndexChanged(object sender, EventArgs e) { 
            
            
            }


 

        private void tipo5ComboBoxEx_SelectedValueChanged(object sender, EventArgs e)
            {
                
            }
        #endregion Cambios Sat

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.cargaImagen(true, articulo.ARTICULO_ID);
            
        }
        private void cargaImagen(bool ActulizaImg, string ARTICULO_ID_) {
            try
            {
                //frmImagenesArticuloIdGoogleDrive frmG = new frmImagenesArticuloIdGoogleDrive(ARTICULO_ID_);
                //frmG.ShowDialog();

                //int paramI= param.ObtenParametro("IMAGENPRODUCTO");
                //if (paramI>0)
                //{                    
                //    string host = SIFNegocio.Configuracion.Configuraciones.ServidorOracle.Host.ToString();
                //    if (ActulizaImg == false)
                //    {
                //        string path = @"\\" + host + "\\articulos_imagen\\" + ARTICULO_ID_ + ".jpg";
                //        if (!System.IO.File.Exists(path))
                //        {
                //            pictureBox1.Image = Image.FromFile(@"\\" + host + "\\articulos_imagen\\inex.jpg");
                //        }
                //        else
                //        {
                //            pictureBox1.Image = Image.FromFile(path);
                //        }
                //    }
                //    else
                //    {
                //        if (MessageBox.Show("Desea Cambiar la imagen del producto", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
                //            return;

                //        SIFNegocio.Articulo articuloL = new SIFNegocio.Articulo();
                //        OpenFileDialog fdlg = new OpenFileDialog();
                //        StreamReader reader = StreamReader.Null;
                //        fdlg.Title = "Seleccione el archivo a Procesar";
                //        fdlg.Filter = "JPG files (*.JPG)|*.jpg";
                //        fdlg.RestoreDirectory = true;
                //        //bool FmtValid = true;
                //        if (fdlg.ShowDialog() == DialogResult.OK)
                //        {

                //            Double Maxbytes = articuloL.maxBytesI();
                //            Double lengthByes = new FileInfo(fdlg.FileName).Length;//obtenemos en tamaño de la imagen  bytes
                //            if (lengthByes > Maxbytes) {
                //                MessageBox.Show("El maximo de bytes permitido es de " + Maxbytes.ToString()
                //                    +Environment.NewLine+"la imagen seleccionada es de "+ lengthByes.ToString()
                //                    , "Alto", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //                return;
                //            }
                //            File.Copy(@fdlg.FileName, @"\\" + host + "\\articulos_imagen\\" + ARTICULO_ID_ + ".jpg");
                //            MessageBox.Show("OK", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //            this.cargaImagen(false, articulo.ARTICULO_ID);
                //        }

                //    }
                //}
            }
            catch (Exception e) {
                MessageBox.Show(e.ToString());

            }
        }


        #region Antimicrobianos
        private void CargaConfAntimicrobianos() {

            // 1. Creamos la lista de colores con su Nombre y su Valor (Color de la librería System.Drawing)
             var listaColores = new[]
             {
                 new { Texto = "ROJO",     Valor = System.Drawing.Color.FromArgb(255, 40, 0) },
                 new { Texto = "AMARILLO", Valor = System.Drawing.Color.FromArgb(255, 255, 0) },
                 new { Texto = "VERDE",    Valor = System.Drawing.Color.FromArgb(0, 128, 0) } // Verde estándar (puedes usar 0, 255, 0 para Lima)
             };

             // 2. Vinculamos la lista al ComboBox
             ColorAntiMicroComboBoxEx.DataSource = listaColores;

             // 3. Le decimos qué propiedad mostrar y cuál guardar internamente
             ColorAntiMicroComboBoxEx.DisplayMember = "Texto";
             ColorAntiMicroComboBoxEx.ValueMember = "Valor";
         


        
        }

        private void seleccionaColorG(string colorTexto) {

            // 1. Separamos el string por las comas
            string[] partes = colorTexto.Split(',');

            // 2. Validamos que realmente tenga los 3 componentes (R, G, B)
            if (partes.Length == 3)
            {
                // 3. Convertimos cada texto a su respectivo número (byte)
                if (byte.TryParse(partes[0], out byte r) &&
                    byte.TryParse(partes[1], out byte g) &&
                    byte.TryParse(partes[2], out byte b))
                {
                    // 4. Reconstruimos el objeto Color
                    System.Drawing.Color colorABuscar = System.Drawing.Color.FromArgb(r, g, b);

                    // 5. Le decimos al ComboBox que seleccione el ítem que coincida con este valor
                    ColorAntiMicroComboBoxEx.SelectedValue = colorABuscar;
                }
            }
        }

       

        #endregion


    }


    
}
