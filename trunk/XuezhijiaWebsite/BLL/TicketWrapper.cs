using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.TicketTableAdapters;
using System.Data;
using DAL;
using BLL;

namespace BLL
{
    public class TicketWrapper : TicketTableAdapter
    {
        public DataTable getall()
        {
            return GetData();
        }

        public List<TICKET> getAllFormatedResult()
        {
            return _transfer(getall());
 
        }

        private  List<TICKET> _transfer(DataTable table)
        {
            List<TICKET> list = new List<TICKET>();
            for (int i = 0; i < table.Rows.Count; i++)
            { 
                TICKET ticket = new TICKET();
                ticket.TicketID = Convert.ToInt32(table.Rows[i]["TicketID"].ToString());
                ticket.TicketName = table.Rows[i]["TicketName"].ToString();
                ticket.DurationOfService = table.Rows[i]["DurationOfService"].ToString();
                ticket.Price = Convert.ToDouble(table.Rows[i]["Price"].ToString());
                ticket.WayToPay = table.Rows[i]["WayToPay"].ToString();
                ticket.LinkURL = table.Rows[i]["LinkURL"].ToString();
                ticket.PID = Convert.ToInt32(table.Rows[i]["PID"].ToString());
                ticket.Comment = table.Rows[i]["Comment"].ToString();
                list.Add(ticket);
            }
            return list;
        }

        public void addARecord(Ticket.TicketRow row)
        {
            Insert(row.TicketName, row.DurationOfService, row.Price, row.WayToPay, row.LinkURL, row.PID, row.Comment);
        }

        public void addAClassRecord(TICKET row)
        {
            Insert(row.TicketName, row.DurationOfService, row.Price, row.WayToPay, row.LinkURL, row.PID, row.Comment);
        }

        public void deleteARecordByID(int id)
        {
            string sql = "delete from Ticket where TicketID = " + id.ToString();
            CommenHelper helper = CommenHelper.GetInstance();
            helper.initOle();
            helper.delete(sql);
        }

        public TICKET getResultByID(int id)
        {
            string sql = "select * from Ticket where TicketID = " + id.ToString();
            DataTable table = new DataTable();
            CommenHelper helper = CommenHelper.GetInstance();
            helper.initOle();
            table = helper.getResultBySql(sql);
            return _transfer(table).First();
        }

        public void updateARecord(TICKET ticket)
        {
            Ticket.TicketDataTable table = new Ticket.TicketDataTable();
            table = GetData();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (Convert.ToInt32(table.Rows[i]["TicketID"].ToString()) == ticket.TicketID)
                {
                    table.Rows[i]["TicketName"] = ticket.TicketName;
                    table.Rows[i]["DurationOfService"] = ticket.DurationOfService;
                    table.Rows[i]["Price"] = ticket.Price;
                    table.Rows[i]["WayToPay"] = ticket.WayToPay;
                    table.Rows[i]["LinkURL"] = ticket.LinkURL;
                    table.Rows[i]["PID"] = ticket.PID;
                    table.Rows[i]["Comment"] = ticket.Comment;
                    break;
                }
            }
            Update(table);
        }
    }
}
