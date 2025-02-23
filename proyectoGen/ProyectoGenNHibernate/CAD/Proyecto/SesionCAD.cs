
using System;
using System.Text;
using ProyectoGenNHibernate.CEN.Proyecto;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using ProyectoGenNHibernate.EN.Proyecto;
using ProyectoGenNHibernate.Exceptions;


/*
 * Clase Sesion:
 *
 */

namespace ProyectoGenNHibernate.CAD.Proyecto
{
public partial class SesionCAD : BasicCAD, ISesionCAD
{
public SesionCAD() : base ()
{
}

public SesionCAD(ISession sessionAux) : base (sessionAux)
{
}



public SesionEN ReadOIDDefault (int id
                                )
{
        SesionEN sesionEN = null;

        try
        {
                SessionInitializeTransaction ();
                sesionEN = (SesionEN)session.Get (typeof(SesionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in SesionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return sesionEN;
}

public System.Collections.Generic.IList<SesionEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<SesionEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(SesionEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<SesionEN>();
                        else
                                result = session.CreateCriteria (typeof(SesionEN)).List<SesionEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in SesionCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (SesionEN sesion)
{
        try
        {
                SessionInitializeTransaction ();
                SesionEN sesionEN = (SesionEN)session.Load (typeof(SesionEN), sesion.Id);

                sesionEN.Hora_inicio = sesion.Hora_inicio;


                sesionEN.Hora_fin = sesion.Hora_fin;




                session.Update (sesionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in SesionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (SesionEN sesion)
{
        try
        {
                SessionInitializeTransaction ();
                if (sesion.Usuario != null) {
                        // Argumento OID y no colección.
                        sesion.Usuario = (ProyectoGenNHibernate.EN.Proyecto.UsuarioEN)session.Load (typeof(ProyectoGenNHibernate.EN.Proyecto.UsuarioEN), sesion.Usuario.Id);

                        sesion.Usuario.Sesion_activa
                                = sesion;
                }

                session.Save (sesion);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in SesionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return sesion.Id;
}

public void Modify (SesionEN sesion)
{
        try
        {
                SessionInitializeTransaction ();
                SesionEN sesionEN = (SesionEN)session.Load (typeof(SesionEN), sesion.Id);

                sesionEN.Hora_inicio = sesion.Hora_inicio;

                session.Update (sesionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in SesionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                SesionEN sesionEN = (SesionEN)session.Load (typeof(SesionEN), id);
                session.Delete (sesionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in SesionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: SesionEN
public SesionEN ReadOID (int id
                         )
{
        SesionEN sesionEN = null;

        try
        {
                SessionInitializeTransaction ();
                sesionEN = (SesionEN)session.Get (typeof(SesionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in SesionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return sesionEN;
}

public System.Collections.Generic.IList<SesionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<SesionEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(SesionEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<SesionEN>();
                else
                        result = session.CreateCriteria (typeof(SesionEN)).List<SesionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in SesionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void CerrarSesion (int p_Sesion_OID, int p_usuario_0_OID)
{
        ProyectoGenNHibernate.EN.Proyecto.SesionEN sesionEN = null;
        try
        {
                SessionInitializeTransaction ();
                sesionEN = (SesionEN)session.Load (typeof(SesionEN), p_Sesion_OID);
                sesionEN.Usuario_0 = (ProyectoGenNHibernate.EN.Proyecto.UsuarioEN)session.Load (typeof(ProyectoGenNHibernate.EN.Proyecto.UsuarioEN), p_usuario_0_OID);

                sesionEN.Usuario_0.Sesion_terminada.Add (sesionEN);



                session.Update (sesionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in SesionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.SesionEN> DameSesionesUsuario (int p_Usuario)
{
        System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.SesionEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM SesionEN self where select ses FROM SesionEN ses INNER JOIN ses.Usuario as usu WHERE usu.Id = :p_Usuario AND ses.Hora_fin IS NULL";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("SesionENdameSesionesUsuarioHQL");
                query.SetParameter ("p_Usuario", p_Usuario);

                result = query.List<ProyectoGenNHibernate.EN.Proyecto.SesionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in SesionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.SesionEN> DameSesionesTerminadasUsuario (int p_Usuario)
{
        System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.SesionEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM SesionEN self where select ses FROM SesionEN ses INNER JOIN ses.Usuario_0 as usu WHERE usu.Id = :p_Usuario";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("SesionENdameSesionesTerminadasUsuarioHQL");
                query.SetParameter ("p_Usuario", p_Usuario);

                result = query.List<ProyectoGenNHibernate.EN.Proyecto.SesionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in SesionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.SesionEN> DameUltimaSesionUsuario (int p_Usuario)
{
        System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.SesionEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM SesionEN self where select ses FROM SesionEN ses INNER JOIN ses.Usuario as usu WHERE usu.Id = :p_Usuario";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("SesionENdameUltimaSesionUsuarioHQL");
                query.SetParameter ("p_Usuario", p_Usuario);

                result = query.List<ProyectoGenNHibernate.EN.Proyecto.SesionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in SesionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
