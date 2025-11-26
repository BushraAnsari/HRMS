
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS
{
    public partial class Main : System.Web.UI.MasterPage
    {
        HRMSEntities dx = new HRMSEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] == null)
            {
                Response.Redirect("Login.aspx");

            }

            if (!Page.IsPostBack)
            {
                BindMenu();
                BindNoti();
            }

        }
        private void BindNoti()
        {
            try
            {
                long userid = long.Parse(Session["userid"].ToString());
                var bind = from a in dx.tbl_noti where a.fk_userid == userid select a;
                var query = bind.AsEnumerable()

                .GroupBy(x => new { x.noti_content, x.read_status })
                .Select(x => new
                {
                    NotiDetails = x.Key.noti_content,
                    unreadcount = x.Key.read_status == false ? x.Count(s => bool.Parse(s.read_status.ToString())) : 0

                });
                rpt_noti.DataSource = query.ToList();
                rpt_noti.DataBind();


            }

            catch (Exception ex)
            {
                //   sm.ErrorLogs(ex.ToString(), "BindMenu", "SiteMasterDashboard");
            }
            try
            {
                long userid = long.Parse(Session["userid"].ToString());
                var bind = from a in dx.tbl_noti where a.fk_userid == userid && a.read_status == false select a;
                var query = bind.AsEnumerable()

                .Select(x => new
                {
                    unreadcount = bind.Count()

                });

                Repeaternoticount.DataSource = query.ToList();
                Repeaternoticount.DataBind();


            }

            catch (Exception ex)
            {
                //   sm.ErrorLogs(ex.ToString(), "BindMenu", "SiteMasterDashboard");
            }
        }
        private void BindMenu()
        {
            try
            {
                long _UserType = long.Parse(Session["usertype"].ToString());
                var showMenu = (from a in dx.tbl_Document
                                where a.Parent == 0 && a.UserType == _UserType
                                select a).ToList();
                //.Distinct().OrderBy(x => x.Sequence);
                rptMainMenu.DataSource = showMenu;
                rptMainMenu.DataBind();

            }
            catch (Exception ex)
            {
                //   sm.ErrorLogs(ex.ToString(), "BindMenu", "SiteMasterDashboard");
            }
        }
        protected void rptMainMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {


                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    long _UserType = long.Parse(Session["usertype"].ToString());
                    Label lblID = (Label)e.Item.FindControl("lblID") as Label;

                    Repeater rptNestedMenu = (Repeater)e.Item.FindControl("rptNestedMenu") as Repeater;

                    long _ParentID = long.Parse(lblID.Text);


                    var showMenu = (from a in dx.tbl_Document
                                    where a.Parent != 0 && a.UserType == _UserType && a.Parent == _ParentID
                                    select a).ToList();

                    rptNestedMenu.DataSource = showMenu;
                    rptNestedMenu.DataBind();



                }
            }
            catch (Exception ex)
            {

            }

        }

        protected void Repeaternoticount_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

                    try
                    {
                        long userid = long.Parse(Session["userid"].ToString());
                        var bind = (from a in dx.tbl_noti where a.fk_userid == userid && a.read_status == false select a).ToList();
                        for (int i = 0; i < bind.Count; i++)
                        {
                            bind[i].read_status = true;
                            dx.SaveChanges();
                        }

                    }

                    catch (Exception ex)
                    {
                        //   sm.ErrorLogs(ex.ToString(), "BindMenu", "SiteMasterDashboard");
                    }



            }
    }
}