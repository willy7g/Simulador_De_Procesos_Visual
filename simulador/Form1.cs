using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace simulador
{
    //**********************************************************************************************
    public partial class Form1 : Form
    {
        //VARIABLES GLOBALES
        /* a = Recurso = 1
           b = Proceso = 2
           c = Procesador =3 
           x = Agregar 1,2 ó 3
           y = Cambio de Procesador
           i = contador de segundos de timer
           t = Tiempo de Vida de Proceso Segun los Hilos del Procesador (1,2,3,4 Hilos)
           mo= memoria ocupada en la lista dinamica y botones
           cr = ciclos recorridos cada 4 ciclos ejecutar el colector*/
        public int a = -1, b = -1, c = -1, x = 0, y = 0,i = 0, tiempoProcesamiento =0, mo=0, cr =0, cr2 = 0;
        Random rnd = new Random();
        List<Recursos> lr = new List<Recursos>();//Lista de Recursos
        List<Procesos> lp = new List<Procesos>();//Lista de Procesos
        List<Procesos> lp2 = new List<Procesos>();//Lista de Procesos Ordenada por prioridad
        List<Procesadores> lps = new List<Procesadores>();//Lista de Procesadores
        Timer t = new Timer();
        List<MarcosDePagina> mp = new List<MarcosDePagina>();//Lista dinamica para Marcos de Pagina
        List<Button> bmp = new List<Button>();//Lista para meter los 16 botones de marco de pagina
        List<Button> bm = new List<Button>();//Lista para meter los 128 botones de memoria
        List<Memoria>  mem = new List<Memoria>();//Lista dinamica para memoria fisica
        //Memoria m = new Memoria();//para hacer referencia a la memoria
        //MarcosDePagina marcos = new MarcosDePagina();//Para hacer referencia a los marcos de pagina
        //******************************************************************************************
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {        
            
            CargarProcesadorPredeterminado();
            cmbVelocidadTimer.SelectedIndex = 0;
            MarcosDePagina();//Crear lista de 4 marcos de pagina  de 16 mb en total
            //iniciarTimer();
            //l.ListaProcesos.Add("uno");
            //INICIO DE PROGRAMA
        }
        //****************Procesador Predeterminado***************************************************
        public void CargarProcesadorPredeterminado() 
        {
           
            /*x = 3;
            siguiente(ref x);
            Procesadores predeterminado = new Procesadores()
            {
                nombre = "1 Hilo",
                hilos = "1",
                estado = "Disponible",
                EnCIclo = 0
            };
            lps.Add(predeterminado);

            foreach (Procesadores ba in lps)
            {
                dataGridViewProcesador.Rows.Add();
                dataGridViewProcesador.Rows[0].Cells["NombreProcesador"].Value = ba.nombre;
                btnProcesadorEnUso.Text = ba.nombre;
                btnProcesadorEnUso.BackColor = Color.Lime;
            }*/
            //m.CrearMemoria();//crear lista dinamica de botones
            bm.Add(btn1);   bm.Add(btn2);   bm.Add(btn3);   bm.Add(btn4);   bm.Add(btn5);   bm.Add(btn6);   bm.Add(btn7);   bm.Add(btn8);   bm.Add(btn9);   bm.Add(btn10);
            bm.Add(btn11);  bm.Add(btn12);  bm.Add(btn13);  bm.Add(btn14);  bm.Add(btn15);  bm.Add(btn16);  bm.Add(btn17);  bm.Add(btn18);  bm.Add(btn19);  bm.Add(btn20);
            bm.Add(btn21);  bm.Add(btn22);  bm.Add(btn23);  bm.Add(btn24);  bm.Add(btn25);  bm.Add(btn26);  bm.Add(btn27);  bm.Add(btn28);  bm.Add(btn29);  bm.Add(btn30);
            bm.Add(btn31);  bm.Add(btn32);  bm.Add(btn33);  bm.Add(btn34);  bm.Add(btn35);  bm.Add(btn36);  bm.Add(btn37);  bm.Add(btn38);  bm.Add(btn39);  bm.Add(btn40);
            bm.Add(btn41);  bm.Add(btn42);  bm.Add(btn43);  bm.Add(btn44);  bm.Add(btn45);  bm.Add(btn46);  bm.Add(btn47);  bm.Add(btn48);  bm.Add(btn49);  bm.Add(btn50);
            bm.Add(btn51);  bm.Add(btn52);  bm.Add(btn53);  bm.Add(btn54);  bm.Add(btn55);  bm.Add(btn56);  bm.Add(btn57);  bm.Add(btn58);  bm.Add(btn59);  bm.Add(btn60);
            bm.Add(btn61);  bm.Add(btn62);  bm.Add(btn63);  bm.Add(btn64);  bm.Add(btn65);  bm.Add(btn66);  bm.Add(btn67);  bm.Add(btn68);  bm.Add(btn69);  bm.Add(btn70);
            bm.Add(btn71);  bm.Add(btn72);  bm.Add(btn73);  bm.Add(btn74);  bm.Add(btn75);  bm.Add(btn76);  bm.Add(btn77);  bm.Add(btn78);  bm.Add(btn79);  bm.Add(btn80);
            bm.Add(btn81);  bm.Add(btn82);  bm.Add(btn83);  bm.Add(btn84);  bm.Add(btn85);  bm.Add(btn86);  bm.Add(btn87);  bm.Add(btn88);  bm.Add(btn89);  bm.Add(btn90);
            bm.Add(btn91);  bm.Add(btn92);  bm.Add(btn93);  bm.Add(btn94);  bm.Add(btn95);  bm.Add(btn96);  bm.Add(btn97);  bm.Add(btn98);  bm.Add(btn99);  bm.Add(btn100);
            bm.Add(btn101); bm.Add(btn102); bm.Add(btn103); bm.Add(btn104); bm.Add(btn105); bm.Add(btn106); bm.Add(btn107); bm.Add(btn108); bm.Add(btn109); bm.Add(btn110);
            bm.Add(btn111); bm.Add(btn112); bm.Add(btn113); bm.Add(btn114); bm.Add(btn115); bm.Add(btn116); bm.Add(btn117); bm.Add(btn118); bm.Add(btn119); bm.Add(btn120);
            bm.Add(btn121); bm.Add(btn122); bm.Add(btn123); bm.Add(btn124); bm.Add(btn125); bm.Add(btn126); bm.Add(btn127); bm.Add(btn128);
            //Lista dinamica de memoria
           int marco=0;
            for (int i = 0; i < 128; i++)
            {
                int residuo = i % 4;
                if (residuo ==0) 
                {
                    marco++;//los siguientes bloques de marcos incrementado
                }
                Memoria n = new Memoria()
                {
                    nombre = i.ToString(),
                    estado = "0",
                    marco = marco
                };
                mem.Add(n);
            }
        }
        //Siguiente incrementar a,b c
        public void siguiente(ref int x) 
        {
            if (x == 1) { a++; }//Incrementar contador de recuros
            if (x == 2) { b++; }//Incrementar contador de procesos
            if (x == 3) { c++; }//Incrementar contador de procesador
        }
        //Funcion para actualizar los combobox despues de agregar un proceso, servicio ó procesador**********
        public void ActualizarCombobox() 
        {
            if (txtNombreRecurso.Text != "" && x ==1)
            {
                cmbListaRecursos.Items.Add(txtNombreRecurso.Text);
                cmbRecursoProceso.Items.Add(txtNombreRecurso.Text);
            }
            if (txtNombreProceso.Text != "" && x == 2)
            {               
                cmbListaProcesos.Items.Add(txtNombreProceso.Text);                 
            }
            if (txtNombreProcesador.Text != "" && x ==3)
            {
                cmbListaProcesadores.Items.Add(txtNombreProcesador.Text);
            }
        }//Fin de funcion actualizar combobox****************************************************************
        //******************************Funcion para Limpiar campos******************************************
        public void Limpiar() 
        {
            //****************************
            txtNombreRecurso.Text = "";            
            //****************************
            txtNombreProceso.Text = "";
            //*****************************
            txtNombreProcesador.Text = "";            
        }//Fin de Limpiar*************************************************************************************
        public bool validar() 
        {    
            //**************************RECURSO***************************************
            if ((txtNombreRecurso.Text == "" || cmbEstadoRecurso.SelectedItem == null) && x ==1) 
            {
                MessageBox.Show("Campos vacios!");
                return false;
                
            }
            //**************************PROCESO***************************************
            if ((txtNombreProceso.Text == "" || cmbEstadoProceso.SelectedIndex == null || cmbPrioridadProceso.SelectedIndex == null || cmbRecursoProceso.SelectedIndex == null)&& x ==2) 
            {
                MessageBox.Show("Campos vacios!");
                return false;
            }
            //**************************PROCESADOR************************************
            if ((txtNombreProcesador.Text == "" || cmbHilosProcesador.SelectedIndex == null)&& x ==3)
            {
                MessageBox.Show("Campos vacios!");
                return false;
            }
            return true;
        }//Fin de Funcion de Validacion***********************************************************************
        public void Agregar() 
        {
            if (x == 1)//***********************Recurso********************************* 
            {
                Recursos n = new Recursos()
                {
                    nombre = txtNombreRecurso.Text, 
                    estado = cmbEstadoRecurso.Text
                };
                lr.Add(n);
            }else
                if (x == 2)//***********************Proceso********************************* 
                {
                    Procesos n = new Procesos()
                    {
                        nombre = txtNombreProceso.Text,
                        estado = cmbEstadoProceso.Text,
                        prioridad = cmbPrioridadProceso.Text,
                        recurso = cmbRecursoProceso.Text,
                        tamaño = cmbTamañoProceso.Text
                    };

                    if (mo + Convert.ToInt32(n.tamaño) > 128)
                    {
                        MessageBox.Show("Este proceso no cabe en memoria! Supera los 128Mb");
                    }
                    else
                    {
                        Random randomGen = new Random();
                        KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
                        KnownColor randomColorName = names[randomGen.Next(names.Length)];
                        Color randomColor = Color.FromKnownColor(randomColorName);//**********************
                        foreach (Memoria m in mem)
                        {
                            if (m.estado == "0" && Convert.ToInt32(n.tamaño) > 0)
                            {
                                m.nombre = n.nombre;
                                m.estado = "1";
                                n.tamaño = Convert.ToString(Convert.ToInt32(n.tamaño) - 1);
                                //**********************************************************generar random color
                                
                                bm[mo].BackColor = randomColor;//******************************************************color random****************************************************
                                mo++;
                            }
                        }
                        lp2.Add(n);
                        OrdenarLista();
                    }
                }else
                    if (x == 3)//***********************Procesador*********************************  
                    {
                        Procesadores n = new Procesadores()
                        {
                           nombre =txtNombreProcesador.Text, 
                           hilos = cmbHilosProcesador.Text                            
                        };
                        lps.Add(n);                
                    }
        }//Fin de Funcion Agregar objetos a la lista**********************************************************
        //****************************************************************************************************
        //*********************************FUNCIONES PARA AGREGAR RECURSO, PROCESO Y PROCESADOR***************
        //**********************************************Agregar Recurso***************************************
        private void btnAgregarRecurso_Click(object sender, EventArgs e)
        {
            x = 1;
            if (!validar()) { return; }
            siguiente(ref x);
            //MessageBox.Show(Convert.ToString(a));
            //Agregar al Grid
            string nombre = txtNombreRecurso.Text, estado = cmbEstadoRecurso.Text;
            dataGridViewCalendarizador.Rows.Add();
            dataGridViewRecurso.Rows.Add();
            dataGridViewCalendarizador.Rows[a].Cells["Recurso"].Value = nombre;
            dataGridViewCalendarizador.Rows[a].Cells["EstadoRecurso"].Value = estado;
            Agregar();//Agregar a la Lista Dinamica
            dataGridViewRecurso.Rows[a].Cells["NombreRecurso"].Value = nombre;//Agregar al dgw de Recursos
            ActualizarCombobox();
            Limpiar();
        }//fin de agregar recurso********************************************************************************
        //*****************************************Agregar Proceso***********************************************
        private void btnAgregarProceso_Click(object sender, EventArgs e)
        {
            x = 2;
            if (!validar()) { return; }
            siguiente(ref x);
            //MessageBox.Show(Convert.ToString(b));
            string nombre = txtNombreProceso.Text, estado = cmbEstadoProceso.Text, Prioridad = cmbPrioridadProceso.Text, recurso = cmbRecursoProceso.Text;
            int i = dataGridViewCalendarizador.Rows.Count;//cuenta las lineas del grid           
            dataGridViewCalendarizador.Rows.Add();
            dataGridViewCalendarizador.Rows[b].Cells["Proceso"].Value = nombre;
            dataGridViewCalendarizador.Rows[b].Cells["EstadoProceso"].Value = estado;
            dataGridViewCalendarizador.Rows[b].Cells["PrioridadProceso"].Value = Prioridad;
            dataGridViewCalendarizador.Rows[b].Cells["RecursoProceso"].Value = recurso;
            Agregar();//Agregar a la Lista Dinamica
            ActualizarCombobox();
            Limpiar();
        }//Fin agregar Proceso************************************************************************************

        //*****************************************Agregar Procesador**********************************************
        private void btnAgregarProcesador_Click(object sender, EventArgs e)
        {
            x = 3;
            if (!validar()) { return; }
            siguiente(ref x);
            //MessageBox.Show(Convert.ToString(a));
            string nombre =txtNombreProcesador.Text, hilos = cmbHilosProcesador.Text;
            dataGridViewCalendarizador.Rows.Add();
            dataGridViewCalendarizador.Rows[c].Cells["Procesador"].Value = nombre;
            dataGridViewCalendarizador.Rows[c].Cells["HilosProcesador"].Value = hilos;
            Agregar();//Agregar a la Lista Dinamica
            dataGridViewProcesador.Rows.Add();
            dataGridViewProcesador.Rows[c].Cells["NombreProcesador"].Value = nombre;//Agregar al dgw de procesadores
            ActualizarCombobox();
            Limpiar();
        }//fin agregar procesador*********************************************************************************
        //*********************************FUNCION ORDENAR PROCESOS EN GRID***************************************************INICIAR SIMULACION***************************************
        private void button1_Click(object sender, EventArgs e)
        {            
            simular();
            CargarProcesoEnMarcoDePagina();//Cargar el PRIMER proceso 
            //simular();
            iniciarTimer();
        }//Fin de funcion buttonclick
        //**********************************FUNCION SIMULAR*******************SIMULAR****************SIMULAR***********************SIMULAR***********************SIMULAR**************
        public void simular()
        {
            if (dataGridViewCalendarizador.Rows.Count != 1)//si hay filas
            {               
                b = 0;                
                dataGridViewCalendarizador.Rows.Clear();
                dataGridViewCalendarizador.Refresh();
                foreach (Procesos ce in lp2.Where(ce => ce.prioridad == "Critica" && ce.estado == "En ejecucion"))
                {
                    dataGridViewCalendarizador.Rows.Add();
                    dataGridViewCalendarizador.Rows[b].Cells["Proceso"].Value = ce.nombre;
                    dataGridViewCalendarizador.Rows[b].Cells["EstadoProceso"].Value = ce.estado;
                    dataGridViewCalendarizador.Rows[b].Cells["PrioridadProceso"].Value = ce.prioridad;
                    dataGridViewCalendarizador.Rows[b].Cells["RecursoProceso"].Value = ce.recurso;
                    dataGridViewCalendarizador.Rows[b].Cells["TProceso"].Value = ce.tamaño;
                    dataGridViewCalendarizador.Rows[b].Cells["ProcesadorEnUso"].Value = ce.ProcesadorEnUso;
                    b++;
                }
                foreach (Procesos c in lp2.Where(c => c.prioridad == "Critica"  && c.estado != "En ejecucion"))
                {
                    dataGridViewCalendarizador.Rows.Add();
                    dataGridViewCalendarizador.Rows[b].Cells["Proceso"].Value = c.nombre;
                    dataGridViewCalendarizador.Rows[b].Cells["EstadoProceso"].Value = c.estado;
                    dataGridViewCalendarizador.Rows[b].Cells["PrioridadProceso"].Value = c.prioridad;
                    dataGridViewCalendarizador.Rows[b].Cells["RecursoProceso"].Value = c.recurso;
                    dataGridViewCalendarizador.Rows[b].Cells["TProceso"].Value = c.tamaño;
                    dataGridViewCalendarizador.Rows[b].Cells["ProcesadorEnUso"].Value = c.ProcesadorEnUso;
                    b++;
                }
                foreach (Procesos ae in lp2.Where(ae => ae.prioridad == "Alta" && ae.estado == "En ejecucion"))
                {
                    dataGridViewCalendarizador.Rows.Add();
                    dataGridViewCalendarizador.Rows[b].Cells["Proceso"].Value = ae.nombre;
                    dataGridViewCalendarizador.Rows[b].Cells["EstadoProceso"].Value = ae.estado;
                    dataGridViewCalendarizador.Rows[b].Cells["PrioridadProceso"].Value = ae.prioridad;
                    dataGridViewCalendarizador.Rows[b].Cells["RecursoProceso"].Value = ae.recurso;
                    dataGridViewCalendarizador.Rows[b].Cells["TProceso"].Value = ae.tamaño;
                    dataGridViewCalendarizador.Rows[b].Cells["ProcesadorEnUso"].Value = ae.ProcesadorEnUso;
                    b++;
                }
                foreach (Procesos a in lp2.Where(a => a.prioridad == "Alta"  && a.estado != "En ejecucion"))
                {
                    dataGridViewCalendarizador.Rows.Add();
                    dataGridViewCalendarizador.Rows[b].Cells["Proceso"].Value = a.nombre;
                    dataGridViewCalendarizador.Rows[b].Cells["EstadoProceso"].Value = a.estado;
                    dataGridViewCalendarizador.Rows[b].Cells["PrioridadProceso"].Value = a.prioridad;
                    dataGridViewCalendarizador.Rows[b].Cells["RecursoProceso"].Value = a.recurso;
                    dataGridViewCalendarizador.Rows[b].Cells["TProceso"].Value = a.tamaño;
                    dataGridViewCalendarizador.Rows[b].Cells["ProcesadorEnUso"].Value = a.ProcesadorEnUso;
                    b++;
                }
                foreach (Procesos me in lp2.Where(me => me.prioridad == "Media" && me.estado == "En ejecucion"))
                {
                    dataGridViewCalendarizador.Rows.Add();
                    dataGridViewCalendarizador.Rows[b].Cells["Proceso"].Value = me.nombre;
                    dataGridViewCalendarizador.Rows[b].Cells["EstadoProceso"].Value = me.estado;
                    dataGridViewCalendarizador.Rows[b].Cells["PrioridadProceso"].Value = me.prioridad;
                    dataGridViewCalendarizador.Rows[b].Cells["RecursoProceso"].Value = me.recurso;
                    dataGridViewCalendarizador.Rows[b].Cells["TProceso"].Value = me.tamaño;
                    dataGridViewCalendarizador.Rows[b].Cells["ProcesadorEnUso"].Value = me.ProcesadorEnUso;
                    b++;
                }
                foreach (Procesos m in lp2.Where(m => m.prioridad == "Media"  && m.estado != "En ejecucion"))
                {
                    dataGridViewCalendarizador.Rows.Add();
                    dataGridViewCalendarizador.Rows[b].Cells["Proceso"].Value = m.nombre;
                    dataGridViewCalendarizador.Rows[b].Cells["EstadoProceso"].Value = m.estado;
                    dataGridViewCalendarizador.Rows[b].Cells["PrioridadProceso"].Value = m.prioridad;
                    dataGridViewCalendarizador.Rows[b].Cells["RecursoProceso"].Value = m.recurso;
                    dataGridViewCalendarizador.Rows[b].Cells["TProceso"].Value = m.tamaño;
                    dataGridViewCalendarizador.Rows[b].Cells["ProcesadorEnUso"].Value = m.ProcesadorEnUso;
                    b++;
                }
                foreach (Procesos bae in lp2.Where(bae => bae.prioridad == "Bajo" && bae.estado == "En ejecucion"))
                {
                    dataGridViewCalendarizador.Rows.Add();
                    dataGridViewCalendarizador.Rows[b].Cells["Proceso"].Value = bae.nombre;
                    dataGridViewCalendarizador.Rows[b].Cells["EstadoProceso"].Value = bae.estado;
                    dataGridViewCalendarizador.Rows[b].Cells["PrioridadProceso"].Value = bae.prioridad;
                    dataGridViewCalendarizador.Rows[b].Cells["RecursoProceso"].Value = bae.recurso;
                    dataGridViewCalendarizador.Rows[b].Cells["TProceso"].Value = bae.tamaño;
                    dataGridViewCalendarizador.Rows[b].Cells["ProcesadorEnUso"].Value = bae.ProcesadorEnUso;
                    b++;
                }
                foreach (Procesos ba in lp2.Where(ba => ba.prioridad == "Bajo"  && ba.estado != "En ejecucion"))
                {
                    dataGridViewCalendarizador.Rows.Add();
                    dataGridViewCalendarizador.Rows[b].Cells["Proceso"].Value = ba.nombre;
                    dataGridViewCalendarizador.Rows[b].Cells["EstadoProceso"].Value = ba.estado;
                    dataGridViewCalendarizador.Rows[b].Cells["PrioridadProceso"].Value = ba.prioridad;
                    dataGridViewCalendarizador.Rows[b].Cells["RecursoProceso"].Value = ba.recurso;
                    dataGridViewCalendarizador.Rows[b].Cells["TProceso"].Value = ba.tamaño;
                    dataGridViewCalendarizador.Rows[b].Cells["ProcesadorEnUso"].Value = ba.ProcesadorEnUso;
                    b++;
                }
                b = 0;
                dataGridViewCalendarizador.Rows[0].DefaultCellStyle.BackColor = Color.Lime;
                //Actualizar Status Labels!!!******************                
                StatusLabelTProceso.Text = "Tamaño de Proceso Actual " + dataGridViewCalendarizador.Rows[0].Cells["TProceso"].Value.ToString() + "MB";//Asignar tamaño de Recurso al label Status
                StatusLabelTProceso.BackColor = Color.SkyBlue;
                labelMemoriaEnUso.Text = "Memoria en Uso = " + mo+"Mb";
                int f = dataGridViewCalendarizador.Rows.Count;//Cuenta la cantidad de filas en el dgv

            }
            else//si no hay filas
            {
                MessageBox.Show("Simulacion Terminada");
                PausarTimer();   
            }

        }//fin de funcion simular
        //**********************************************************************CARGAR PROCESO EN MARCOS DE PAGINA**********************MARCOS DE PAGINA*********************************************************************        
        public void CargarProcesoEnMarcoDePagina() 
        {
            int h = 0;//tamáño de proceso a cargar
            string hnombre = "";//Nombre de proceso a cargar 
            string hrecurso = "";//Recurso al que apunta el proceso actual
            int pd = 0;//Paginas de memoria disponibles en total
            int po = 0;//Paginas occupadas en total
            int pn = 0;//Pocisiones necesarias para agregar un proceso cuando no cabe.

            foreach (Procesos p in lp2.Where(p => p.estado != "En memoria" || p.estado != "Finalizado"))
            {         
                
                
                h = Convert.ToInt32(p.tamaño);
                hnombre = p.nombre;
                hrecurso = p.recurso;
                /*
                //Recorrer la lista para ver cuantas paginas hay disponibles y cuantas ocupadas
                for (int i = 0; i < 16; i++)//Recorre la cantidad de memoria a utilizar 
                {
                    if (mp[i].estado == "1") { po++; }//Pagina Ocupada
                    else
                        if (mp[i].estado == "0") { pd++; }//Pagina Disponible      
                }
                pn = h - pd;*/


                //****************************************************************************************************
                //if (h <= pd)//si el proceso cabe en los marcos de paginas disponibles
                //{               
                for (int i = 0; i < 16 && p.tamañoEnMemoria < Convert.ToInt32(p.tamaño); i++)//Recorre la cantidad de memoria a utilizar 
                {
                    if (mp[i].estado == "0")
                    {
                        mp[i].nombre = hnombre;//nombre del proceso en pagina
                        mp[i].estado = "1";//ocupado
                        mp[i].recursoApuntado = hrecurso;//apuntando a recurso de este proceso
                        bmp[i].Text = hnombre + "--->" + hrecurso;//descripcion visual de la pagina 
                       // h--;//rebaja las cantidades de pagina necesarias para el proceso
                        p.tamañoEnMemoria++; 
                        p.estado = "En ejecucion"; 
                    }
                }
                if (p.tamañoEnMemoria == h) { p.estado = "En memoria"; }
            }
            
            //}  
            /*else//Si el proceso no cabe**********LIBERAR ESPACIO DE MEMORIA***************************************
            {
                iniciarTimer2();
                for (int k = 0; k < 16 && pn > 0; k++)
                {
                    if (mp[k].estado == "1")
                    {
                        mp[k].estado = "0";//Limpia la pagina                            
                        pn--;//rebaja las cantidades de pagina necesarias para el proceso
                    }
                }
                CargarProcesoEnMarcoDePagina();//Recursividad se llama a esta misma funcion para que hoy si agregue el proceso.
                labelMarcoPagina.Text = "Espacio disponible";
                labelMarcoPagina.BackColor = Color.Transparent;
            }
            */
            
            /*
            else//Si el proceso no cabe**********LIBERAR ESPACIO DE MEMORIA***************************************
            {
                iniciarTimer2();                
                    for (int k = 0; k < 16 && pn > 0; k++)
                    {
                        if (mp[k].estado == "1")
                        {
                            mp[k].estado = "0";//Limpia la pagina                            
                            pn--;//rebaja las cantidades de pagina necesarias para el proceso
                        }
                    }
                CargarProcesoEnMarcoDePagina();//Recursividad se llama a esta misma funcion para que hoy si agregue el proceso.
                labelMarcoPagina.Text = "Espacio disponible";
                labelMarcoPagina.BackColor = Color.Transparent;
            }*/
        }//Fin de funcion de Marco de Pagina
        //********************************************************************************************************
        //****************************************************************************TIMER**************TIMER******************TIMER***********TIMER**************************TIMER*****TIMER********
        public void timer1_Tick(object sender, EventArgs e)
        {
            
            string estado = "";
            VelocidadEjecucion();
            if(i==0){
            //Medir la velocidad en 1X 4X 8X 16X
            //if (y == 1)//Se cambio el procesador
            //{
                CalculoDeTiempoPorHilos();//Calcular nuevo tiempo limite del proceso segun Hilos del Procesador
              //  y = 0;
               // i = 0;
            //}
            }
            i++;
            if (i == 1 ) 
            {
               


                //Asigna una pagina a cada proceso que este disponible para procesarla
                foreach (Procesadores p in lps.Where(p => p.estado == "Disponible" && p.EnCIclo == 0)) 
                {
                    
                        for (int j = 0; j < 16; j++)//Recorre la cantidad de memoria a utilizar 
                        {
                            foreach (Recursos r in lr.Where(r => r.nombre == mp[j].recursoApuntado))
                            {
                                estado = r.estado; //toma el estado del recurso del marco de pagina actual del bucle
                            }//Bloquear este recurso para otro procesador en este ciclo





                            if (mp[j].estado == "1")//si el marco de pagina esta ocupado y el recurso al que apunta esta disponible*****
                            {

                                if (estado == "Disponible")
                                {
                                    p.ejecutandoProceso = mp[j].nombre;//nombre del proceso que procesara este procesador
                                    mp[j].estado = "2";//proceso Ejecutandose
                                    bmp[j].BackColor = Color.Lime;//color de pagina verde procesando
                                    foreach (Recursos r in lr.Where(r => r.nombre == mp[j].recursoApuntado)) { r.estado = "En Uso"; }//Bloquear este recurso para otro procesador en este ciclo
                                    p.estado = "Ocupado";//Este procesador esta Ocupado     
                                    p.EnCIclo = 1;
                                    foreach (Procesos q in lp2.Where(q => q.nombre == mp[j].nombre))
                                    { q.estado = "Procesando"; q.ProcesadorEnUso = p.nombre; }
                                    break;//salir del if si ya tomo un recurso
                                }
                                else 
                                {
                                    foreach (Procesos q in lp2.Where(q => q.nombre == mp[j].nombre)) 
                                    {
                                        if (q.estado == "Procesando") { }
                                        else { q.estado = "Bloqueado"; }
                                    } 
                                   
                                }
                            }
                        }                   

                }//fin de foreach                
            }

           

                        

                    //Liberar Recurso y Procesador, rebajar la pagina del tamaño de proceso
                    foreach (Procesadores p2 in lps.Where(p2 => p2.vida == i && p2.estado == "Ocupado"))
                    {
                            //p2.EnCIclo++;//termino su ciclo y se pone en espera de los demas procesadores                            

                        for (int j = 0; j < 16; j++)//Recorre la cantidad de memoria a utilizar 
                        {
                            if (mp[j].nombre == p2.ejecutandoProceso && mp[j].estado == "2")//si el marco de pagina tiene el proceso que estaba ejecutando el procesador*****
                            {
                                p2.ejecutandoProceso = "";//vacio
                                mp[j].estado = "3";//pagina Finalizada
                                bmp[j].BackColor = Color.Red;//color de pagina verde procesando
                                foreach (Recursos r in lr.Where(r => r.nombre == mp[j].recursoApuntado)) { r.estado = "CasiDisponible"; }//Desbloquear este recurso para otro procesador en este ciclo
                                p2.estado = "Disponible";//Este procesador esta Ocupado
                                p2.EnCIclo = 2;
                                foreach (Procesos q in lp2.Where(q => q.nombre == mp[j].nombre)) { q.tamañoProcesado++; q.estado = "En ejecucion"; q.ProcesadorEnUso = ""; }//rebajar pagina de proceso                                
                                
                            }
                        }


                    }
                    //P.ciclo = 1   procesando
                    //p.Ciclo = 2   Termino de procesar
                    //p.Ciclo = 0   Procesador disponible   

                    int ciclo = 0;                  

                    foreach (Procesadores p3 in lps)
                    {
                        if (p3.EnCIclo == 1) 
                        {
                            ciclo++;
                        }
                        else 
                        {
                            
                        }

  
                    }

                    if (ciclo == 0)//si no hay un proceso en ciclo
                    {
                        cr++;
                        i = 0;
                        foreach (Procesadores p3 in lps)
                        {
                            p3.EnCIclo = 0;
                        }
                        foreach (Recursos r in lr) { r.estado = "Disponible"; }//Desbloquear este recurso para otro procesador en este ciclo

                        int residuo = cr % 4;
                        if (residuo == 0)
                        {
                            LlamarColector();
                        }
                        StatusLabelCiclos.Text = cr + " Ciclos";

                    }
                    else { ciclo = 0; }


                    labelTimer.Text = i.ToString();
                    btnRecursoEnUso.Text = dataGridViewCalendarizador.Rows[0].Cells["RecursoProceso"].Value.ToString();

                    btnRecursoEnUso.BackColor = Color.Lime;            
                    simular();
                
                //cmbColectorProcesos.Items.Add(dataGridViewCalendarizador.Rows[0].Cells["Proceso"].Value.ToString());//*************cada 4 corridas
                
                //dataGridViewCalendarizador.Rows.RemoveAt(0);//eliminar este proceso finalizado                
                //Siguiente Proceso
                
                //CargarProcesoEnMarcoDePagina();
                               
            
        }//Fin de bucle timer
        //********************************************************
        int z = 0; string cargando = "liberando memoria..";

        private void timer2_Tick(object sender, EventArgs e)
        {            
            z++;  
            cargando = cargando + ".";
            labelMarcoPagina.Text = cargando;
            labelMarcoPagina.BackColor = Color.Lime;
            if (z == 45) 
            { 
                PausarTimer2(); z = 0; 
                cargando = "liberando memoria.."; 
            }
        }//FIN DE FUNCIONES DE TIMER*********************
        //************************************************************************COLECTOR DE PROCESOS****************************COLECTOR*********************COLECTOR*****************************
        public void LlamarColector() 
        {
            
            foreach (Procesos m in lp2.Where(m => m.tamaño == Convert.ToString(m.tamañoProcesado)))//Busca el proceso en la lista y le pone estado finalizado
                {
               
                        //LIBERAR MEMORIA FISICA DE PROCESO TERMINADO
                        foreach (Memoria me in mem)
                        {
                            if (me.nombre == m.nombre)
                            {
                                me.nombre = "Vacio";
                                me.estado = "0";                        
                                bm[me.btn].BackColor = Color.Black;//******************************************************color random****************************************************                                
                               // m.estado = "Finalizado";
                            }
                        }
                        //LIBERAR MARCOS DE PAGINA DE PROCESO TERMINADO
                        for (int i = 0; i < 16; i++)
                        {
                            if (mp[i].nombre == m.nombre && mp[i].estado == "3") 
                            {
                                bmp[i].Text = "vacio";
                                bmp[i].BackColor = Color.Gray;
                                mp[i].estado = "0";//libera marco de pagina de lista dinamica
                            }
                         }

                    mo = mo - Convert.ToInt32(m.tamaño);
                    cmbColectorProcesos.Items.Add(m.nombre);//*************cada 4 corridas
                    m.estado = "Finalizado";
                    m.tamañoProcesado++;//incrementa en uno aqui el tamaño procesado es mayor que el tamaño del proceso para indicar que es un proceso finalizado
                    m.tamañoEnMemoria++;
                   
                }

            //limpia marco de pagina de procesos no finalizados pero que ya terminaron ese marco!
            for (int j = 0; j < 16; j++)
            {
                if (mp[j].estado == "3")
                {                     
                    bmp[j].Text = "vacio";
                    bmp[j].BackColor = Color.Gray;
                    mp[j].estado = "0";//libera marco de pagina de lista dinamica
                   
                }
            }
            iniciarTimer2();
            CargarProcesoEnMarcoDePagina();
            //dataGridViewCalendarizador.Rows.RemoveAt(0);//eliminar este proceso finalizado   
        }
        //*************************************FUNCION TIMER********************************************************************************        
        public void iniciarTimer()
        {
            timer1.Enabled = true;
        }
        public void PausarTimer()
        {
            timer1.Stop();
        }
        public void borrarTimer()
        {
            timer1.Stop();
            labelTimer.Text = "";
            i = 0;
        }
        //*************************************************
        public void iniciarTimer2()
        {
            timer2.Enabled = true;
        }
        public void PausarTimer2()
        {
            timer2.Stop();
        }
        public void borrarTimer2()
        {
            timer2.Stop();
            i = 0;
        }
        //********************************************METER PROCESO A MARCOS DE PAGINA***************MARCOS DE PAGINA **************MARCOS DE PAGINA******************************************
        public void CargarProcesoEnMemoria()
        {
            int h = 0;//tamáño de proceso a cargar
            string hnombre = "";//Nombre de proceso a cargar            
            int pd = 0;//Paginas de memoria disponibles en total
            int po = 0;//Paginas occupadas en total
            int pn = 0;//Pocisiones necesarias para agregar un proceso cuando no cabe.

            //******************REVISAR
            h = Convert.ToInt32(dataGridViewCalendarizador.Rows[0].Cells["TProceso"].Value.ToString());
            hnombre = dataGridViewCalendarizador.Rows[0].Cells["Proceso"].Value.ToString();
            //Recorrer la lista para ver cuantas paginas hay disponibles y cuantas ocupadas
            for (int i = 0; i < 16; i++)//Recorre la cantidad de memoria a utilizar 
            {
                if (mp[i].estado == "1") { po++; }//Pagina Ocupada
                else
                    if (mp[i].estado == "0") { pd++; }//Pagina Disponible      
            }
            pn = h - pd;
            //****************************************************************************************************
            if (h <= pd)//si el proceso cabe en los marcos de paginas disponibles
            {
                for (int i = 0; i < 16 && h > 0; i++)//Recorre la cantidad de memoria a utilizar 
                {
                    if (mp[i].estado == "0")
                    {
                        mp[i].nombre = hnombre;
                        mp[i].estado = "1";
                        bmp[i].Text = hnombre;
                        h--;//rebaja las cantidades de pagina necesarias para el proceso
                    }
                }
            }
        }//Fin de agregar procesos a memoria
        //**********************************************RECURSOS AUTOMATICOS*********PROCESOS AUTOMATICOS******************RECURSOS AUTOMATICOS************PROCESOS AUTOMATICOS**************
        private void recursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 25; i++)
            {
                x = 1;
                //if (!validar()) { return; }
                siguiente(ref x);
                //MessageBox.Show(Convert.ToString(a));
                //Agregar al Grid
                string nombre = txtNombreRecurso.Text, estado = cmbEstadoRecurso.Text;
                //dataGridViewCalendarizador.Rows.Add();
                dataGridViewRecurso.Rows.Add();
                //dataGridViewCalendarizador.Rows[a].Cells["Recurso"].Value = nombre;
                //dataGridViewCalendarizador.Rows[a].Cells["EstadoRecurso"].Value = estado;
                Recursos n = new Recursos()
                {                   
                    nombre = "R"+i,
                    estado = "Disponible",
                    tamaño = rnd.Next(1,4).ToString()//Nuevo Parametro
                };
                lr.Add(n); 
                dataGridViewRecurso.Rows[a].Cells["NombreRecurso"].Value = n.nombre;//Agregar al dgw de Recursos
                cmbListaRecursos.Items.Add(n.nombre);//Actualizar cmb
                cmbRecursoProceso.Items.Add(n.nombre);//Actualizar cmb
            }
        }//Fin de funcion simular Recursos
        private void procesosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int memoriaTotal = 0;//cantidad de procesos en memoria
            for (int i = 1; i <= 100; i++)
            {
                //Crear color Random*************************************************************************
                Random randomGen = new Random();
                KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
                KnownColor randomColorName = names[randomGen.Next(names.Length)];
                Color randomColor = Color.FromKnownColor(randomColorName);//*********************************          
                string[] priorida = { "Bajo", "Media", "Alta", "Critica" };//Prioridad ramdon de proceso
                int rand = rnd.Next(0, priorida.Length);//Prioridad Randon
                int rand2 = rnd.Next(0, lr.Count);//Recurso
                x = 2;               
                siguiente(ref x);   
                //Agregar a la Lista Dinamica
                Procesos n = new Procesos()
                {
                    nombre = "P" + i,
                    estado = "En espera",
                    prioridad = priorida[rand],
                    recurso = lr[rand2].nombre,
                    tamaño = rnd.Next(1,16).ToString(),
                    ProcesadorEnUso = ""

                };
                memoriaTotal = memoriaTotal + Convert.ToInt32(n.tamaño);//sumando la memoria ocupada
                if (memoriaTotal > 128)
                {                    
                    memoriaTotal = memoriaTotal - Convert.ToInt32(n.tamaño);
                    MessageBox.Show("Este proceso ya no cabe en la memoria de 128Mb" + (memoriaTotal));
                    lp2.Clear();
                    OrdenarLista();
                    labelMemoriaEnUso.Text = "Memoria en Uso = " + mo + "Mb";
                    return;
                }
                else
                {
                    lp.Add(n);//Agregar a lista
                    //********************Agregar a Calendarizador**********************************
                    dataGridViewCalendarizador.Rows.Add();
                    dataGridViewCalendarizador.Rows[b].Cells["Proceso"].Value = n.nombre;
                    dataGridViewCalendarizador.Rows[b].Cells["EstadoProceso"].Value = n.estado;
                    dataGridViewCalendarizador.Rows[b].Cells["PrioridadProceso"].Value = n.prioridad;
                    dataGridViewCalendarizador.Rows[b].Cells["RecursoProceso"].Value = n.recurso;
                    dataGridViewCalendarizador.Rows[b].Cells["TProceso"].Value = n.tamaño;
                    dataGridViewCalendarizador.Rows[b].Cells["ProcesadorEnUso"].Value = n.ProcesadorEnUso;
                    //***********************Actualizar botones de memoria***********************
                    int tproceso = Convert.ToInt32(n.tamaño);
                    

                    foreach (Memoria m in mem)
                    {
                        if(m.estado == "0" && tproceso > 0)
                        {                            
                        m.nombre = n.nombre;
                        m.estado = "1";
                        tproceso--;
                        bm[mo].BackColor = randomColor;//******************************************************color random****************************************************
                        m.btn = mo;//asignar el boton que representa esta pagina de memoria en el form
                        mo++;
                        }
                        
                    }
                    //****************************************************************************
                    cmbListaProcesos.Items.Add(n.nombre);//Agregar a cmb

                   
                }
            }            
        }//Fin de funcion simular procesos
        private void procesadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
            for (int i = 1; i <= 4; i++)
            {
                x = 3;
                siguiente(ref x);
                //Agregar a la Lista Dinamica
                Procesadores n = new Procesadores()
                {
                   nombre = i + " Hilos",
                   hilos = i.ToString(),
                   estado =  "Disponible",
                   EnCIclo = 0
                };
                lps.Add(n);//Agregar a lista
                dataGridViewProcesador.Rows.Add();
                dataGridViewProcesador.Rows[c].Cells["NombreProcesador"].Value = n.nombre;//Agregar al dgw de procesadores
                ActualizarCombobox();
            }
        }//Fin de funcion simular procesadores
       /*********************************************************************************************************************************/
        //*********************************Funcion para velocidad del timer 1x 4x 8x 16x*************************************************
        public void VelocidadEjecucion() 
        {
            if (cmbVelocidadTimer.SelectedIndex == 0)
            {
                timer1.Interval = 1000;
            }else
                if (cmbVelocidadTimer.SelectedIndex == 1)
                {
                    timer1.Interval = 250;
                }else
                    if (cmbVelocidadTimer.SelectedIndex == 2) 
                    {
                        timer1.Interval = 125;
                    }else timer1.Interval = 62;
        }//Fin de funcion de Velocidad de Timer
        //*****************************Funcion para cambiar procesador en uso************************************************************
        private void dataGridViewProcesador_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)//*********************PROCESADOR POR CLICK EN DGV****************
        {          
            btnProcesadorEnUso.Text = dataGridViewProcesador.CurrentRow.Cells[0].Value.ToString();
            StatusLabelProcesador.Text = "Uso de Procesador de " + dataGridViewProcesador.CurrentRow.Cells[0].Value.ToString();
            StatusLabelProcesador.BackColor = Color.Violet;
            y = 1;//Cambio de procesador Bandera! Activada!
        }//Fin de funcion cambiar procesador
        //**********************************************************************************************************************************TIEMPO PROCESO POR HILOS******************************
        public void CalculoDeTiempoPorHilos()//************ 
        {
            //int t = Convert.ToInt32(dataGridViewCalendarizador.Rows[0].Cells["TProceso"].Value.ToString());  
             foreach (Procesadores p in lps)
             {
                 int Hilos = Convert.ToInt32(p.hilos.ToString());
                 int TiempoVida = 15;

                  tiempoProcesamiento = TiempoVida / Hilos;
                  p.vida = tiempoProcesamiento;
                  StatusLabelTime.Text = "Tiempo Estimado " + Convert.ToString(tiempoProcesamiento.ToString())+"Seg";
                  StatusLabelTime.BackColor = Color.Tomato;
             }            
        }
        //Actualizar StatusLabel de velocidad de procesamiento
        private void cmbVelocidadTimer_SelectedIndexChanged(object sender, EventArgs e)
        {
            StatusLabelVelocidad.Text = "Velocidad " + cmbVelocidadTimer.SelectedItem.ToString();
            StatusLabelVelocidad.BackColor = Color.Lime;
        }//Fin de funcion de Actualizar StatusLabel Procesamiento
        //********************************Funcion para crear la lista de los marcos de pagina********************
        public void MarcosDePagina()
        {
            //marcos.CrearMarcos();
            for (int i = 0; i < 16; i++)
            {
                MarcosDePagina n = new MarcosDePagina()
                {
                    nombre = i.ToString(),
                    estado = "0"
                };
                mp.Add(n);
            }
            //**********************************Agregar los botones del form a una lista dinamica para estarles actualizando el nombre*******************
            bmp.Add(btnMP1); bmp.Add(btnMP2); bmp.Add(btnMP3); bmp.Add(btnMP4); bmp.Add(btnMP5); bmp.Add(btnMP6); bmp.Add(btnMP7); bmp.Add(btnMP8);
            bmp.Add(btnMP9); bmp.Add(btnMP10); bmp.Add(btnMP11); bmp.Add(btnMP12); bmp.Add(btnMP13); bmp.Add(btnMP14); bmp.Add(btnMP15); bmp.Add(btnMP16);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            PausarTimer();
            PausarTimer2();
        }//Fin de crear lista de marcos de pagina

        public void OrdenarLista() 
        {            
                foreach (Procesos p in lp.Where(p => p.prioridad == "Critica"))
                {
                  lp2.Add(p);
                }  
            foreach (Procesos p in lp.Where(p => p.prioridad == "Alta"))
                {
                  lp2.Add(p);
                }  
            foreach (Procesos p in lp.Where(p => p.prioridad == "Media"))
                {
                  lp2.Add(p);
                }  
            foreach (Procesos p in lp.Where(p => p.prioridad == "Bajo"))
                {
                  lp2.Add(p);
                }  
        }

        private void reiniciarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Application.Restart();
        }

        private void recursosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            lr.Clear();
            a = -1;
        }

        private void procesosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            lp.Clear();
            lp2.Clear();
            b = -1;
        }

        private void procesadoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            lps.Clear();
            c = -1;
        }
    }//Fin de main************************************************************************************************
}//Fin del Programa***********************************************************************************************


/*
foreach (DataGridViewRow row in dataGridViewCalendarizador.Rows)
{               
    row.Cells[0].Value = nombre;
    row.Cells[3].Value = estado;
}*/