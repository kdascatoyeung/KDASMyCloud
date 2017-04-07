using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using KDTHK_DM_SP.eforms.acc;

namespace KDTHK_DM_SP.utils
{
    public class PdfUtil
    {
        public static void ExportOutstandingForm(string filename, string vendor, string vendorname, string invoice, string inputdate, string paymentdate, string currency, string total,
            string applicant, string created, string sect, string sectapptime, string div, string divapptime, string dept, string deptapptime, List<OutstandingDetailData> list)
        {
            Document document = new Document(PageSize.A4, 0, 0, 10, 2);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create));

            document.Open();

            Font fontTitle = FontFactory.GetFont("Calibri", 14);
            Font fontContent = FontFactory.GetFont("Calibri", 9);
            Font fontHeader = FontFactory.GetFont("Calibri", 7);

            PdfPTable table = new PdfPTable(12);

            PdfPCell cHeader = new PdfPCell(new Phrase("Outstanding Payment Request Form", fontTitle));
            cHeader.HorizontalAlignment = Element.ALIGN_LEFT;
            cHeader.Border = Rectangle.NO_BORDER;
            cHeader.Colspan = 6;

            PdfPCell cCompany = new PdfPCell(new Phrase("Kyocera Document Technology Co(H.K) Limited", fontContent));
            cCompany.HorizontalAlignment = Element.ALIGN_RIGHT;
            cCompany.VerticalAlignment = Element.ALIGN_BOTTOM;
            cCompany.Border = Rectangle.NO_BORDER;
            cCompany.Colspan = 6;

            table.AddCell(cHeader);
            table.AddCell(cCompany);

            PdfPCell cEmpty = new PdfPCell(new Phrase(" ", fontContent));
            cEmpty.Colspan = 12;
            cEmpty.Border = Rectangle.NO_BORDER;

            table.AddCell(cEmpty);
            table.AddCell(cEmpty);

            PdfPCell chVendor = new PdfPCell(new Phrase("Vendor", fontHeader));

            PdfPCell cVendor = new PdfPCell(new Phrase(vendor, fontContent));
            cVendor.Colspan = 2;

            PdfPCell chVendorName = new PdfPCell(new Phrase("Vendor Name", fontHeader));
            chVendorName.Colspan = 2;
            chVendorName.HorizontalAlignment = Element.ALIGN_CENTER;

            PdfPCell cVendorName = new PdfPCell(new Phrase(vendorname, fontContent));
            cVendorName.Colspan = 7;

            table.AddCell(chVendor);
            table.AddCell(cVendor);
            table.AddCell(chVendorName);
            table.AddCell(cVendorName);

            PdfPCell chInvoice = new PdfPCell(new Phrase("Invoice", fontHeader));
            
            PdfPCell cInvoice = new PdfPCell(new Phrase(invoice, fontContent));
            cInvoice.Colspan = 2;

            PdfPCell chInput = new PdfPCell(new Phrase("Input Date", fontHeader));
            chInput.Colspan = 2;
            chInput.HorizontalAlignment = Element.ALIGN_CENTER;

            PdfPCell cInput = new PdfPCell(new Phrase(inputdate, fontContent));
            cInput.Colspan = 2;

            PdfPCell chPayment = new PdfPCell(new Phrase("Payment Date", fontHeader));
            chPayment.HorizontalAlignment = Element.ALIGN_CENTER;
            chPayment.Colspan = 2;

            PdfPCell cPayment = new PdfPCell(new Phrase(paymentdate, fontContent));
            cPayment.Colspan = 3;

            table.AddCell(chInvoice);
            table.AddCell(cInvoice);
            table.AddCell(chInput);
            table.AddCell(cInput);
            table.AddCell(chPayment);
            table.AddCell(cPayment);

            PdfPCell chCurrency = new PdfPCell(new Phrase("Currency", fontHeader));

            PdfPCell cCurrency = new PdfPCell(new Phrase(currency, fontContent));
            cCurrency.Colspan = 2;

            PdfPCell chTotal = new PdfPCell(new Phrase("Invoice Amount", fontHeader));
            chTotal.Colspan = 2;
            chTotal.HorizontalAlignment = Element.ALIGN_CENTER;

            PdfPCell cTotal = new PdfPCell(new Phrase(total, fontContent));
            cTotal.Colspan = 2;

            PdfPCell cTemp = new PdfPCell(new Phrase(" ", fontContent));
            cTemp.Border = Rectangle.NO_BORDER;
            cTemp.Colspan = 5;

            table.AddCell(chCurrency);
            table.AddCell(cCurrency);
            table.AddCell(chTotal);
            table.AddCell(cTotal);
            table.AddCell(cTemp);

            table.AddCell(cEmpty);
            table.AddCell(cEmpty);

            PdfPCell chAccountCode = new PdfPCell(new Phrase("Account Code", fontHeader));
            chAccountCode.Colspan = 3;

            PdfPCell chCostCentre = new PdfPCell(new Phrase("CostCentre", fontHeader));
            chCostCentre.Colspan = 3;

            PdfPCell chAmount = new PdfPCell(new Phrase("Amount", fontHeader));

            PdfPCell chRemarks1 = new PdfPCell(new Phrase("Remarks", fontHeader));
            chRemarks1.Colspan = 5;

            table.AddCell(chAccountCode);
            table.AddCell(chCostCentre);
            table.AddCell(chAmount);
            table.AddCell(chRemarks1);

            int count = 0;

            foreach (OutstandingDetailData item in list)
            {
                PdfPCell cAccountCode = new PdfPCell(new Phrase(item.AccountCode, fontHeader));
                cAccountCode.Border = Rectangle.LEFT_BORDER;
                cAccountCode.Colspan = 3;

                PdfPCell cCostCentre = new PdfPCell(new Phrase(item.CostCentre, fontHeader));
                cCostCentre.Border = Rectangle.LEFT_BORDER;
                cCostCentre.Colspan = 3;

                PdfPCell cAmount = new PdfPCell(new Phrase(item.Amount, fontHeader));
                cAmount.Border = Rectangle.LEFT_BORDER;

                PdfPCell cRemarks1 = new PdfPCell(new Phrase(item.Remarks1, fontHeader));
                cRemarks1.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                cRemarks1.Colspan = 5;
                
                table.AddCell(cAccountCode);
                table.AddCell(cCostCentre);
                table.AddCell(cAmount);
                table.AddCell(cRemarks1);

                count++;
            }

            do
            {
                PdfPCell cAccountCode = new PdfPCell(new Phrase(" ", fontHeader));
                cAccountCode.Border = Rectangle.LEFT_BORDER;
                cAccountCode.Colspan = 3;

                PdfPCell cCostCentre = new PdfPCell(new Phrase(" ", fontHeader));
                cCostCentre.Border = Rectangle.LEFT_BORDER;
                cCostCentre.Colspan = 3;

                PdfPCell cAmount = new PdfPCell(new Phrase(" ", fontHeader));
                cAmount.Border = Rectangle.LEFT_BORDER;

                PdfPCell cRemarks1 = new PdfPCell(new Phrase(" ", fontHeader));
                cRemarks1.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                cRemarks1.Colspan = 5;
                
                table.AddCell(cAccountCode);
                table.AddCell(cCostCentre);
                table.AddCell(cAmount);
                table.AddCell(cRemarks1);

                count++;
            }
            while (count < 35);

            PdfPCell ctAccountCode = new PdfPCell();
            ctAccountCode.Border = Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
            ctAccountCode.Colspan = 3;

            PdfPCell ctCostCentre = new PdfPCell();
            ctCostCentre.Border = Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
            ctCostCentre.Colspan = 3;

            PdfPCell ctAmount = new PdfPCell();
            ctAmount.Border = Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;

            PdfPCell ctRemarks1 = new PdfPCell();
            ctRemarks1.Colspan = 5;
            ctRemarks1.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.BOTTOM_BORDER;

            table.AddCell(ctAccountCode);
            table.AddCell(ctCostCentre);
            table.AddCell(ctAmount);
            table.AddCell(ctRemarks1);

            string createdby = applicant + " created at " + created;
            string section = sect + " approved at " + sectapptime;
            string division = div + " approved at " + divapptime;
            string department = dept != "" ? dept + " approved at " + deptapptime : " ";

            table.AddCell(cEmpty);
            table.AddCell(cEmpty);

            PdfPCell chCreated = new PdfPCell(new Phrase(createdby, fontContent));
            chCreated.Colspan = 6;
            chCreated.Border = Rectangle.NO_BORDER;

            PdfPCell chMgt = new PdfPCell(new Phrase("Management Control Department", fontHeader));
            chMgt.HorizontalAlignment = Element.ALIGN_CENTER;
            chMgt.Colspan = 6;

            table.AddCell(chCreated);
            table.AddCell(chMgt);

            PdfPCell chSection = new PdfPCell(new Phrase(section, fontContent));
            chSection.Colspan = 6;
            chSection.Border = Rectangle.NO_BORDER;

            PdfPCell chApprover = new PdfPCell(new Phrase("Staff", fontHeader));
            chApprover.HorizontalAlignment = Element.ALIGN_CENTER;
            chApprover.Colspan = 2;

            PdfPCell chReviewer = new PdfPCell(new Phrase("Reviewer", fontHeader));
            chReviewer.HorizontalAlignment = Element.ALIGN_CENTER;
            chReviewer.Colspan = 2;

            PdfPCell chStaff = new PdfPCell(new Phrase("Approver", fontHeader));
            chStaff.HorizontalAlignment = Element.ALIGN_CENTER;
            chStaff.Colspan = 2;

            table.AddCell(chSection);
            table.AddCell(chApprover);
            table.AddCell(chReviewer);
            table.AddCell(chStaff);

            PdfPCell chDivision = new PdfPCell(new Phrase(division, fontContent));
            chDivision.Colspan = 6;
            chDivision.Border = Rectangle.NO_BORDER;

            PdfPCell ctApprover = new PdfPCell(new Phrase(" ", fontContent));
            ctApprover.Border = Rectangle.LEFT_BORDER;
            ctApprover.Colspan = 2;

            PdfPCell ctReviewer = new PdfPCell(new Phrase(" ", fontContent));
            ctReviewer.Border = Rectangle.LEFT_BORDER;
            ctReviewer.Colspan = 2;

            PdfPCell ctStaff = new PdfPCell(new Phrase(" ", fontContent));
            ctStaff.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
            ctStaff.Colspan = 2;

            table.AddCell(chDivision);
            table.AddCell(ctApprover);
            table.AddCell(ctReviewer);
            table.AddCell(ctStaff);

            PdfPCell chDepartment = new PdfPCell(new Phrase(department, fontContent));
            chDepartment.Colspan = 6;
            chDepartment.Border = Rectangle.NO_BORDER;

            table.AddCell(chDepartment);
            table.AddCell(ctApprover);
            table.AddCell(ctReviewer);
            table.AddCell(ctStaff);

            PdfPCell chBottom = new PdfPCell();
            chBottom.Colspan = 6;
            chBottom.Border = Rectangle.NO_BORDER;

            table.AddCell(chBottom);
            table.AddCell(ctApprover);
            table.AddCell(ctReviewer);
            table.AddCell(ctStaff);

            table.AddCell(chBottom);
            table.AddCell(ctApprover);
            table.AddCell(ctReviewer);
            table.AddCell(ctStaff);

            table.AddCell(chBottom);
            table.AddCell(ctApprover);
            table.AddCell(ctReviewer);
            table.AddCell(ctStaff);

            PdfPCell cbApprover = new PdfPCell();
            cbApprover.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.BOTTOM_BORDER;
            cbApprover.Colspan = 2;

            PdfPCell cbReviewer = new PdfPCell();
            cbReviewer.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.BOTTOM_BORDER;
            cbReviewer.Colspan = 2;

            PdfPCell cbStaff = new PdfPCell();
            cbStaff.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.BOTTOM_BORDER;
            cbStaff.Colspan = 2;

            table.AddCell(chBottom);
            table.AddCell(cbApprover);
            table.AddCell(cbReviewer);
            table.AddCell(cbStaff);

            document.Add(table);
            document.Close();
        }

        public static void ExportForm(string filename, string type, string reqDate, string reqOffice, string reqCostCentre, string custCode, string custName,
            string custCurr, string payterm, string duedate, string custDiv, string divName, string incharge, string reqItem,
            string reason, string manual, string invNo, string ringiNo, string month, string dnCurr1, string dnTotal1,
            string dnCurr2, string dnTotal2, string tranReason1, string ac1, string cc1, string invCurr1, string invTotal1,
            string invCurr1_1, string invTotal1_1, string tranReason2, string ac2, string cc2, string invCurr2, string invTotal2,
            string invCurr2_1, string invTotal2_1, string tranReason3, string ac3, string cc3, string invCurr3, string invTotal3,
            string invCurr3_1, string invTotal3_1, string tranReason4, string ac4, string cc4, string invCurr4, string invTotal4,
            string invCurr4_1, string invTotal4_1, string tranReason5, string ac5, string cc5, string invCurr5, string invTotal5,
            string invCurr5_1, string invTotal5_1)
        {
            Document document = new Document(PageSize.A4, 1, 1, 10, 2);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create));

            document.Open();

            Font fontTitle = FontFactory.GetFont("Calibri", 16);
            Font fontContent = FontFactory.GetFont("Calibri", 9);
            Font fontWhite = FontFactory.GetFont("Calibri", 9, BaseColor.WHITE);
            Font fontBold = FontFactory.GetFont("Calibri", 8, Font.BOLD);
            Font fontBoldSmall = FontFactory.GetFont("Calibri", 7, Font.BOLD);
            Font fontStamp = FontFactory.GetFont("Calibri", 8);
            Font fontBottom = FontFactory.GetFont("Calibri", 6);

            BaseFont bfChinese = BaseFont.CreateFont(@"C:\Windows\Fonts\simhei.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

            Font chineseFont = new Font(bfChinese, 9);

            PdfPTable pTable = new PdfPTable(26);

            #region Header
            PdfPCell chHeader = new PdfPCell(new Phrase(type == "debit" ? "DEBIT NOTE REQUEST FORM" : "CREDIT NOTE REQUEST FORM", fontTitle));
            chHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            chHeader.Border = Rectangle.NO_BORDER;
            chHeader.Colspan = 26;
            pTable.AddCell(chHeader);

            PdfPCell cEmpty = new PdfPCell(new Phrase(" ", fontContent));
            cEmpty.Border = Rectangle.NO_BORDER;
            cEmpty.Colspan = 26;
            pTable.AddCell(cEmpty);

            PdfPCell chEmpty = new PdfPCell(new Phrase("", fontStamp));
            chEmpty.Border = Rectangle.NO_BORDER;
            chEmpty.Colspan = 10;
            pTable.AddCell(chEmpty);

            PdfPCell chDeptIncharge = new PdfPCell(new Phrase("Dep. Incharge", fontStamp));
            chDeptIncharge.HorizontalAlignment = Element.ALIGN_CENTER;
            chDeptIncharge.Colspan = 4;
            pTable.AddCell(chDeptIncharge);

            PdfPCell chDivIncharge = new PdfPCell(new Phrase("Div. Incharge", fontStamp));
            chDivIncharge.HorizontalAlignment = Element.ALIGN_CENTER;
            chDivIncharge.Colspan = 4;
            pTable.AddCell(chDivIncharge);

            PdfPCell chSecIncharge = new PdfPCell(new Phrase("Sec. Incharge", fontStamp));
            chSecIncharge.HorizontalAlignment = Element.ALIGN_CENTER;
            chSecIncharge.Colspan = 4;
            pTable.AddCell(chSecIncharge);

            PdfPCell chIncharge = new PdfPCell(new Phrase("Incharge", fontStamp));
            chIncharge.HorizontalAlignment = Element.ALIGN_CENTER;
            chIncharge.Colspan = 4;
            pTable.AddCell(chIncharge);

            pTable.AddCell(chEmpty);

            PdfPCell chStamp = new PdfPCell(new Phrase(" \n\n\n\n\n\n\n\n", fontStamp));
            chStamp.Colspan = 4;
            pTable.AddCell(chStamp);
            pTable.AddCell(chStamp);
            pTable.AddCell(chStamp);
            pTable.AddCell(chStamp);

            pTable.AddCell(cEmpty);
            #endregion

            PdfPCell cReqDate = new PdfPCell(new Phrase("REQUEST DATE", fontBold));
            cReqDate.HorizontalAlignment = Element.ALIGN_CENTER;
            cReqDate.Colspan = 5;
            //cReqDate.BackgroundColor = BaseColor.DARK_GRAY;
            pTable.AddCell(cReqDate);

            PdfPCell cdReqDate = new PdfPCell(new Phrase(reqDate, fontContent));
            cdReqDate.HorizontalAlignment = Element.ALIGN_CENTER;
            cdReqDate.Colspan = 3;
            pTable.AddCell(cdReqDate);

            PdfPCell cReqOffice = new PdfPCell(new Phrase("OFFICE", fontBold));
            cReqOffice.HorizontalAlignment = Element.ALIGN_CENTER;
            //cReqOffice.BackgroundColor = BaseColor.DARK_GRAY;
            cReqOffice.Colspan = 3;
            pTable.AddCell(cReqOffice);

            PdfPCell cdReqOffice = new PdfPCell(new Phrase(reqOffice, chineseFont));
            cdReqOffice.HorizontalAlignment = Element.ALIGN_CENTER;
            cdReqOffice.Colspan = 5;
            pTable.AddCell(cdReqOffice);

            PdfPCell cReqCostCentre = new PdfPCell(new Phrase("COSTCENTRE", fontBold));
            cReqCostCentre.HorizontalAlignment = Element.ALIGN_CENTER;
            //cReqCostCentre.BackgroundColor = BaseColor.DARK_GRAY;
            cReqCostCentre.Colspan = 4;
            pTable.AddCell(cReqCostCentre);

            PdfPCell cdReqCostCentre = new PdfPCell(new Phrase(reqCostCentre, chineseFont));
            cdReqCostCentre.HorizontalAlignment = Element.ALIGN_CENTER;
            cdReqCostCentre.Colspan = 6;
            pTable.AddCell(cdReqCostCentre);

            pTable.AddCell(cEmpty);

            PdfPCell cCustCode = new PdfPCell(new Phrase("CUST. CODE", fontBold));
            cCustCode.HorizontalAlignment = Element.ALIGN_CENTER;
            //cCustCode.BackgroundColor = BaseColor.DARK_GRAY;
            cCustCode.Colspan = 5;
            pTable.AddCell(cCustCode);

            PdfPCell cdCustCode = new PdfPCell(new Phrase(custCode, chineseFont));
            cdCustCode.HorizontalAlignment = Element.ALIGN_CENTER;
            cdCustCode.Colspan = 4;
            pTable.AddCell(cdCustCode);

            PdfPCell cCustName = new PdfPCell(new Phrase("CUST. NAME", fontBold));
            cCustName.HorizontalAlignment = Element.ALIGN_CENTER;
            //cCustName.BackgroundColor = BaseColor.DARK_GRAY;
            cCustName.Colspan = 5;
            pTable.AddCell(cCustName);

            PdfPCell cdCustName = new PdfPCell(new Phrase(custName, chineseFont));
            cdCustName.HorizontalAlignment = Element.ALIGN_CENTER;
            cdCustName.Colspan = 12;
            pTable.AddCell(cdCustName);

            PdfPCell cCustCurr = new PdfPCell(new Phrase("CUST. CURR", fontBold));
            cCustCurr.HorizontalAlignment = Element.ALIGN_CENTER;
            //cCustCurr.BackgroundColor = BaseColor.DARK_GRAY;
            cCustCurr.Colspan = 5;
            pTable.AddCell(cCustCurr);

            PdfPCell cdCustCurr = new PdfPCell(new Phrase(custCurr, chineseFont));
            cdCustCurr.HorizontalAlignment = Element.ALIGN_CENTER;
            cdCustCurr.Colspan = 4;
            pTable.AddCell(cdCustCurr);

            PdfPCell cPayterm = new PdfPCell(new Phrase("PAY TERM", fontBold));
            cPayterm.HorizontalAlignment = Element.ALIGN_CENTER;
            //cPayterm.BackgroundColor = BaseColor.DARK_GRAY;
            cPayterm.Colspan = 3;
            pTable.AddCell(cPayterm);

            PdfPCell cdPayterm = new PdfPCell(new Phrase(payterm, chineseFont));
            cdPayterm.HorizontalAlignment = Element.ALIGN_CENTER;
            cdPayterm.Colspan = 4;
            pTable.AddCell(cdPayterm);

            PdfPCell cDueDate = new PdfPCell(new Phrase("DUE DATE", fontBold));
            cDueDate.HorizontalAlignment = Element.ALIGN_CENTER;
            //cDueDate.BackgroundColor = BaseColor.DARK_GRAY;
            cDueDate.Colspan = 4;
            pTable.AddCell(cDueDate);

            PdfPCell cdDueDate = new PdfPCell(new Phrase(duedate, chineseFont));
            cdDueDate.HorizontalAlignment = Element.ALIGN_CENTER;
            cdDueDate.Colspan = 6;
            pTable.AddCell(cdDueDate);

            PdfPCell cCustDiv = new PdfPCell(new Phrase("CUST. DIV", fontBold));
            cCustDiv.HorizontalAlignment = Element.ALIGN_CENTER;
            //cCustDiv.BackgroundColor = BaseColor.DARK_GRAY;
            cCustDiv.Colspan = 5;
            pTable.AddCell(cCustDiv);

            PdfPCell cdCustDiv = new PdfPCell(new Phrase(custDiv, chineseFont));
            cdCustDiv.HorizontalAlignment = Element.ALIGN_CENTER;
            cdCustDiv.Colspan = 4;
            pTable.AddCell(cdCustDiv);

            PdfPCell cDivName = new PdfPCell(new Phrase("DIV. NAME", fontBold));
            cDivName.HorizontalAlignment = Element.ALIGN_CENTER;
            //cDivName.BackgroundColor = BaseColor.DARK_GRAY;
            cDivName.Colspan = 3;
            pTable.AddCell(cDivName);

            PdfPCell cdDivName = new PdfPCell(new Phrase(divName, chineseFont));
            cdDivName.HorizontalAlignment = Element.ALIGN_CENTER;
            cdDivName.Colspan = 6;
            pTable.AddCell(cdDivName);

            PdfPCell cIncharge = new PdfPCell(new Phrase("INCHARGE", fontBold));
            cIncharge.HorizontalAlignment = Element.ALIGN_CENTER;
            //cIncharge.BackgroundColor = BaseColor.DARK_GRAY;
            cIncharge.Colspan = 4;
            pTable.AddCell(cIncharge);

            PdfPCell cdIncharge = new PdfPCell(new Phrase(incharge, chineseFont));
            cdIncharge.HorizontalAlignment = Element.ALIGN_CENTER;
            cdIncharge.Colspan = 4;
            pTable.AddCell(cdIncharge);

            PdfPCell cReqItem = new PdfPCell(new Phrase("\n\n\n\nREQUEST ITEM\n\n\n\n\n", fontBold));
            cReqItem.HorizontalAlignment = Element.ALIGN_CENTER;
            //cReqItem.BackgroundColor = BaseColor.DARK_GRAY;
            cReqItem.Colspan = 5;
            pTable.AddCell(cReqItem);

            PdfPCell cdReqItem = new PdfPCell(new Phrase(reqItem, chineseFont));
            cdReqItem.Colspan = 21;
            pTable.AddCell(cdReqItem);

            PdfPCell cReasonAuto = new PdfPCell(new Phrase("REASON", fontBold));
            cReasonAuto.HorizontalAlignment = Element.ALIGN_CENTER;
            //cReasonAuto.BackgroundColor = BaseColor.DARK_GRAY;
            cReasonAuto.Colspan = 5;
            pTable.AddCell(cReasonAuto);

            PdfPCell cdReasonAuto = new PdfPCell(new Phrase(reason, chineseFont));
            cdReasonAuto.Colspan = 21;
            pTable.AddCell(cdReasonAuto);

            PdfPCell cRemarks = new PdfPCell(new Phrase("\n\nREMARKS\n\n\n", fontBold));
            cRemarks.HorizontalAlignment = Element.ALIGN_CENTER;
            //cRemarks.BackgroundColor = BaseColor.DARK_GRAY;
            cRemarks.Colspan = 5;
            pTable.AddCell(cRemarks);

            PdfPCell cdRemarks = new PdfPCell(new Phrase(manual, chineseFont));
            cdRemarks.Colspan = 21;
            pTable.AddCell(cdRemarks);

            PdfPCell cInvno = new PdfPCell(new Phrase("INV. NO", fontBold));
            cInvno.HorizontalAlignment = Element.ALIGN_CENTER;
            //cInvno.BackgroundColor = BaseColor.DARK_GRAY;
            cInvno.Colspan = 5;
            pTable.AddCell(cInvno);

            PdfPCell cdInvno = new PdfPCell(new Phrase(invNo, chineseFont));
            cdInvno.Colspan = 21;
            pTable.AddCell(cdInvno);

            PdfPCell cRingino = new PdfPCell(new Phrase("RINGI NO", fontBold));
            cRingino.HorizontalAlignment = Element.ALIGN_CENTER;
            //cRingino.BackgroundColor = BaseColor.DARK_GRAY;
            cRingino.Colspan = 5;
            pTable.AddCell(cRingino);

            PdfPCell cdRingino = new PdfPCell(new Phrase(ringiNo, chineseFont));
            cdRingino.Colspan = 21;
            pTable.AddCell(cdRingino);

            PdfPCell cDetailEmpty = new PdfPCell(new Phrase(" ", fontContent));
            //cDetailEmpty.BackgroundColor = BaseColor.DARK_GRAY;
            cDetailEmpty.Colspan = 5;
            pTable.AddCell(cDetailEmpty);

            PdfPCell cMonth = new PdfPCell(new Phrase("MONTH", fontBold));
            cMonth.HorizontalAlignment = Element.ALIGN_CENTER;
            //cMonth.BackgroundColor = BaseColor.DARK_GRAY;
            cMonth.Colspan = 4;
            pTable.AddCell(cMonth);

            PdfPCell cTotalForeign = new PdfPCell(new Phrase("DN TOTAL AMOUNT (FOREIGN)", fontBold));
            cTotalForeign.HorizontalAlignment = Element.ALIGN_CENTER;
            //cTotalForeign.BackgroundColor = BaseColor.DARK_GRAY;
            cTotalForeign.Colspan = 9;
            pTable.AddCell(cTotalForeign);

            PdfPCell cTotalLocal = new PdfPCell(new Phrase("DN TOTAL AMOUNT (LOCAL)", fontBold));
            cTotalLocal.HorizontalAlignment = Element.ALIGN_CENTER;
            //cTotalLocal.BackgroundColor = BaseColor.DARK_GRAY;
            cTotalLocal.Colspan = 8;
            pTable.AddCell(cTotalLocal);

            PdfPCell cDetail = new PdfPCell(new Phrase("DETAIL", fontBold));
            cDetail.HorizontalAlignment = Element.ALIGN_CENTER;
            //cDetail.BackgroundColor = BaseColor.DARK_GRAY;
            cDetail.Colspan = 5;
            pTable.AddCell(cDetail);

            PdfPCell cdMonth = new PdfPCell(new Phrase(month, chineseFont));
            cdMonth.HorizontalAlignment = Element.ALIGN_CENTER;
            cdMonth.Colspan = 4;
            pTable.AddCell(cdMonth);

            PdfPCell cDnCurr1 = new PdfPCell(new Phrase(dnCurr1, chineseFont));
            cDnCurr1.HorizontalAlignment = Element.ALIGN_CENTER;
            cDnCurr1.Colspan = 3;
            pTable.AddCell(cDnCurr1);

            PdfPCell cDnTotal1 = new PdfPCell(new Phrase(dnTotal1, chineseFont));
            cDnTotal1.HorizontalAlignment = Element.ALIGN_CENTER;
            cDnTotal1.Colspan = 6;
            pTable.AddCell(cDnTotal1);

            PdfPCell cDnCurr2 = new PdfPCell(new Phrase(dnCurr2, chineseFont));
            cDnCurr2.HorizontalAlignment = Element.ALIGN_CENTER;
            cDnCurr2.Colspan = 3;
            pTable.AddCell(cDnCurr2);

            PdfPCell cDnTotal2 = new PdfPCell(new Phrase(dnTotal2, chineseFont));
            cDnTotal2.HorizontalAlignment = Element.ALIGN_CENTER;
            cDnTotal2.Colspan = 5;
            pTable.AddCell(cDnTotal2);

            #region Transaction
            pTable.AddCell(cDetailEmpty);

            PdfPCell cTranReason = new PdfPCell(new Phrase("REASON", fontBold));
            cTranReason.HorizontalAlignment = Element.ALIGN_CENTER;
            //cTranReason.BackgroundColor = BaseColor.DARK_GRAY;
            cTranReason.Colspan = 6;
            pTable.AddCell(cTranReason);

            PdfPCell cAccountCode = new PdfPCell(new Phrase("A/C CODE", fontBold));
            cAccountCode.HorizontalAlignment = Element.ALIGN_CENTER;
            //cAccountCode.BackgroundColor = BaseColor.DARK_GRAY;
            cAccountCode.Colspan = 4;
            pTable.AddCell(cAccountCode);

            PdfPCell cCostCentre = new PdfPCell(new Phrase("COSTCENTRE", fontBoldSmall));
            cCostCentre.HorizontalAlignment = Element.ALIGN_CENTER;
            //cCostCentre.BackgroundColor = BaseColor.DARK_GRAY;
            cCostCentre.Colspan = 3;
            pTable.AddCell(cCostCentre);

            PdfPCell cInvTotal1 = new PdfPCell(new Phrase("INV TOTAL", fontBold));
            cInvTotal1.HorizontalAlignment = Element.ALIGN_CENTER;
            //cInvTotal1.BackgroundColor = BaseColor.DARK_GRAY;
            cInvTotal1.Colspan = 4;
            pTable.AddCell(cInvTotal1);
            pTable.AddCell(cInvTotal1);

            //========================================================================
            pTable.AddCell(cDetailEmpty);

            PdfPCell cdTranReason1 = new PdfPCell(new Phrase(tranReason1, chineseFont));
            cdTranReason1.HorizontalAlignment = Element.ALIGN_CENTER;
            cdTranReason1.Colspan = 6;
            pTable.AddCell(cdTranReason1);

            PdfPCell cdAccountCode1 = new PdfPCell(new Phrase(ac1, fontStamp));
            cdAccountCode1.HorizontalAlignment = Element.ALIGN_CENTER;
            cdAccountCode1.Colspan = 4;
            pTable.AddCell(cdAccountCode1);

            PdfPCell cdCostCentre1 = new PdfPCell(new Phrase(cc1, fontStamp));
            cdCostCentre1.HorizontalAlignment = Element.ALIGN_CENTER;
            cdCostCentre1.Colspan = 3;
            pTable.AddCell(cdCostCentre1);

            PdfPCell cdInvCurr1 = new PdfPCell(new Phrase(invCurr1, fontBottom));
            cdInvCurr1.HorizontalAlignment = Element.ALIGN_CENTER;
            pTable.AddCell(cdInvCurr1);

            PdfPCell cdInvTotal1 = new PdfPCell(new Phrase(invTotal1, fontStamp));
            cdInvTotal1.HorizontalAlignment = Element.ALIGN_CENTER;
            cdInvTotal1.Colspan = 3;
            pTable.AddCell(cdInvTotal1);

            PdfPCell cdInvCurr1_1 = new PdfPCell(new Phrase(invCurr1_1, fontBottom));
            cdInvCurr1_1.HorizontalAlignment = Element.ALIGN_CENTER;
            pTable.AddCell(cdInvCurr1_1);

            PdfPCell cdInvTotal1_1 = new PdfPCell(new Phrase(invTotal1_1, fontStamp));
            cdInvTotal1_1.HorizontalAlignment = Element.ALIGN_CENTER;
            cdInvTotal1_1.Colspan = 3;
            pTable.AddCell(cdInvTotal1_1);
            //========================================================================

            pTable.AddCell(cDetailEmpty);

            PdfPCell cdTranReason2 = new PdfPCell(new Phrase(tranReason2, chineseFont));
            cdTranReason2.HorizontalAlignment = Element.ALIGN_CENTER;
            cdTranReason2.Colspan = 6;
            pTable.AddCell(cdTranReason2);

            PdfPCell cdAccountCode2 = new PdfPCell(new Phrase(ac2, fontStamp));
            cdAccountCode2.HorizontalAlignment = Element.ALIGN_CENTER;
            cdAccountCode2.Colspan = 4;
            pTable.AddCell(cdAccountCode2);

            PdfPCell cdCostCentre2 = new PdfPCell(new Phrase(cc2, fontStamp));
            cdCostCentre2.HorizontalAlignment = Element.ALIGN_CENTER;
            cdCostCentre2.Colspan = 3;
            pTable.AddCell(cdCostCentre2);

            PdfPCell cdInvCurr2 = new PdfPCell(new Phrase(invCurr2, fontBottom));
            cdInvCurr2.HorizontalAlignment = Element.ALIGN_CENTER;
            pTable.AddCell(cdInvCurr2);

            PdfPCell cdInvTotal2 = new PdfPCell(new Phrase(invTotal2, fontStamp));
            cdInvTotal2.HorizontalAlignment = Element.ALIGN_CENTER;
            cdInvTotal2.Colspan = 3;
            pTable.AddCell(cdInvTotal2);

            PdfPCell cdInvCurr2_1 = new PdfPCell(new Phrase(invCurr2_1, fontBottom));
            cdInvCurr2_1.HorizontalAlignment = Element.ALIGN_CENTER;
            pTable.AddCell(cdInvCurr2_1);

            PdfPCell cdInvTotal2_1 = new PdfPCell(new Phrase(invTotal2_1, fontStamp));
            cdInvTotal2_1.HorizontalAlignment = Element.ALIGN_CENTER;
            cdInvTotal2_1.Colspan = 3;
            pTable.AddCell(cdInvTotal2_1);
            //========================================================================

            PdfPCell cTransaction = new PdfPCell(new Phrase("TRANSACTION", fontBold));
            cTransaction.HorizontalAlignment = Element.ALIGN_CENTER;
            //cTransaction.BackgroundColor = BaseColor.DARK_GRAY;
            cTransaction.Colspan = 5;
            pTable.AddCell(cTransaction);

            PdfPCell cdTranReason3 = new PdfPCell(new Phrase(tranReason3, chineseFont));
            cdTranReason3.HorizontalAlignment = Element.ALIGN_CENTER;
            cdTranReason3.Colspan = 6;
            pTable.AddCell(cdTranReason3);

            PdfPCell cdAccountCode3 = new PdfPCell(new Phrase(ac3, fontStamp));
            cdAccountCode3.HorizontalAlignment = Element.ALIGN_CENTER;
            cdAccountCode3.Colspan = 4;
            pTable.AddCell(cdAccountCode3);

            PdfPCell cdCostCentre3 = new PdfPCell(new Phrase(cc3, fontStamp));
            cdCostCentre3.HorizontalAlignment = Element.ALIGN_CENTER;
            cdCostCentre3.Colspan = 3;
            pTable.AddCell(cdCostCentre3);

            PdfPCell cdInvCurr3 = new PdfPCell(new Phrase(invCurr3, fontBottom));
            cdInvCurr3.HorizontalAlignment = Element.ALIGN_CENTER;
            pTable.AddCell(cdInvCurr3);

            PdfPCell cdInvTotal3 = new PdfPCell(new Phrase(invTotal3, fontStamp));
            cdInvTotal3.HorizontalAlignment = Element.ALIGN_CENTER;
            cdInvTotal3.Colspan = 3;
            pTable.AddCell(cdInvTotal3);

            PdfPCell cdInvCurr3_1 = new PdfPCell(new Phrase(invCurr3_1, fontBottom));
            cdInvCurr3_1.HorizontalAlignment = Element.ALIGN_CENTER;
            pTable.AddCell(cdInvCurr3_1);

            PdfPCell cdInvTotal3_1 = new PdfPCell(new Phrase(invTotal3_1, fontStamp));
            cdInvTotal3_1.HorizontalAlignment = Element.ALIGN_CENTER;
            cdInvTotal3_1.Colspan = 3;
            pTable.AddCell(cdInvTotal3_1);
            //========================================================================

            pTable.AddCell(cDetailEmpty);

            PdfPCell cdTranReason4 = new PdfPCell(new Phrase(tranReason4, chineseFont));
            cdTranReason4.HorizontalAlignment = Element.ALIGN_CENTER;
            cdTranReason4.Colspan = 6;
            pTable.AddCell(cdTranReason4);

            PdfPCell cdAccountCode4 = new PdfPCell(new Phrase(ac4, fontStamp));
            cdAccountCode4.HorizontalAlignment = Element.ALIGN_CENTER;
            cdAccountCode4.Colspan = 4;
            pTable.AddCell(cdAccountCode4);

            PdfPCell cdCostCentre4 = new PdfPCell(new Phrase(cc4, fontStamp));
            cdCostCentre4.HorizontalAlignment = Element.ALIGN_CENTER;
            cdCostCentre4.Colspan = 3;
            pTable.AddCell(cdCostCentre4);

            PdfPCell cdInvCurr4 = new PdfPCell(new Phrase(invCurr4, fontBottom));
            cdInvCurr4.HorizontalAlignment = Element.ALIGN_CENTER;
            pTable.AddCell(cdInvCurr4);

            PdfPCell cdInvTotal4 = new PdfPCell(new Phrase(invTotal4, fontStamp));
            cdInvTotal4.HorizontalAlignment = Element.ALIGN_CENTER;
            cdInvTotal4.Colspan = 3;
            pTable.AddCell(cdInvTotal4);

            PdfPCell cdInvCurr4_1 = new PdfPCell(new Phrase(invCurr4_1, fontBottom));
            cdInvCurr4_1.HorizontalAlignment = Element.ALIGN_CENTER;
            pTable.AddCell(cdInvCurr4_1);

            PdfPCell cdInvTotal4_1 = new PdfPCell(new Phrase(invTotal4_1, fontStamp));
            cdInvTotal4_1.HorizontalAlignment = Element.ALIGN_CENTER;
            cdInvTotal4_1.Colspan = 3;
            pTable.AddCell(cdInvTotal4_1);
            //========================================================================

            pTable.AddCell(cDetailEmpty);

            PdfPCell cdTranReason5 = new PdfPCell(new Phrase(tranReason5, chineseFont));
            cdTranReason5.HorizontalAlignment = Element.ALIGN_CENTER;
            cdTranReason5.Colspan = 6;
            pTable.AddCell(cdTranReason5);

            PdfPCell cdAccountCode5 = new PdfPCell(new Phrase(ac5, fontStamp));
            cdAccountCode5.HorizontalAlignment = Element.ALIGN_CENTER;
            cdAccountCode5.Colspan = 4;
            pTable.AddCell(cdAccountCode5);

            PdfPCell cdCostCentre5 = new PdfPCell(new Phrase(cc5, fontStamp));
            cdCostCentre5.HorizontalAlignment = Element.ALIGN_CENTER;
            cdCostCentre5.Colspan = 3;
            pTable.AddCell(cdCostCentre5);

            PdfPCell cdInvCurr5 = new PdfPCell(new Phrase(invCurr5, fontBottom));
            cdInvCurr5.HorizontalAlignment = Element.ALIGN_CENTER;
            pTable.AddCell(cdInvCurr5);

            PdfPCell cdInvTotal5 = new PdfPCell(new Phrase(invTotal5, fontStamp));
            cdInvTotal5.HorizontalAlignment = Element.ALIGN_CENTER;
            cdInvTotal5.Colspan = 3;
            pTable.AddCell(cdInvTotal5);

            PdfPCell cdInvCurr5_1 = new PdfPCell(new Phrase(invCurr5_1, fontBottom));
            cdInvCurr5_1.HorizontalAlignment = Element.ALIGN_CENTER;
            pTable.AddCell(cdInvCurr5_1);

            PdfPCell cdInvTotal5_1 = new PdfPCell(new Phrase(invTotal5_1, fontStamp));
            cdInvTotal5_1.HorizontalAlignment = Element.ALIGN_CENTER;
            cdInvTotal5_1.Colspan = 3;
            pTable.AddCell(cdInvTotal5_1);
            #endregion

            pTable.AddCell(cEmpty);
            pTable.AddCell(cEmpty);

            PdfPCell cCmTitle = new PdfPCell(new Phrase("(MANAGEMENT CONTROL DIVISION USE ONLY)", fontContent));
            cCmTitle.Border = Rectangle.NO_BORDER;
            cCmTitle.Colspan = 26;
            pTable.AddCell(cCmTitle);

            PdfPCell cDebitNoteNo = new PdfPCell(new Phrase("\nDEBIT NOTE NO.\n", fontBold));
            //cDebitNoteNo.BackgroundColor = BaseColor.DARK_GRAY;
            cDebitNoteNo.HorizontalAlignment = Element.ALIGN_MIDDLE;
            cDebitNoteNo.Colspan = 5;
            pTable.AddCell(cDebitNoteNo);

            PdfPCell cdDebitNoteNo = new PdfPCell(new Phrase("\n \n", chineseFont));
            cdDebitNoteNo.Colspan = 21;
            pTable.AddCell(cdDebitNoteNo);

            PdfPCell cPostDate = new PdfPCell(new Phrase("\nPOSTING DATE\n", fontBold));
            //cPostDate.BackgroundColor = BaseColor.DARK_GRAY;
            cPostDate.Colspan = 5;
            pTable.AddCell(cPostDate);

            PdfPCell cdPostDate = new PdfPCell(new Phrase("\n \n", chineseFont));
            cdPostDate.Colspan = 21;
            pTable.AddCell(cdPostDate);

            PdfPCell cDocNo = new PdfPCell(new Phrase("\nR/3 DOC. NO.\n", fontBold));
            //cDocNo.BackgroundColor = BaseColor.DARK_GRAY;
            cDocNo.Colspan = 5;
            pTable.AddCell(cDocNo);

            PdfPCell cdDocNo = new PdfPCell(new Phrase("\n \n", chineseFont));
            cdDocNo.Colspan = 21;
            pTable.AddCell(cdDocNo);

            PdfPCell cTrans = new PdfPCell(new Phrase("TRANSACTION", fontBold));
            //cTrans.BackgroundColor = BaseColor.DARK_GRAY;
            cTrans.Colspan = 5;
            pTable.AddCell(cTrans);

            PdfPCell cTransDr = new PdfPCell(new Phrase("DR: ", fontContent));
            cTransDr.Colspan = 5;
            pTable.AddCell(cTransDr);

            PdfPCell cTransHK1 = new PdfPCell(new Phrase("HK$ ", fontContent));
            cTransHK1.Colspan = 5;
            pTable.AddCell(cTransHK1);

            PdfPCell cTransCr = new PdfPCell(new Phrase("CR : ", fontContent));
            cTransCr.Colspan = 5;
            pTable.AddCell(cTransCr);

            PdfPCell cTransHK2 = new PdfPCell(new Phrase("HK$ ", fontContent));
            cTransHK2.Colspan = 6;
            pTable.AddCell(cTransHK2);

            pTable.AddCell(cEmpty);

            PdfPCell cBottom = new PdfPCell(new Phrase(" ", fontContent));
            cBottom.Colspan = 14;
            cBottom.Border = Rectangle.NO_BORDER;
            pTable.AddCell(cBottom);

            PdfPCell cBottomCM = new PdfPCell(new Phrase("MANAGEMENT CONTROL ONLY", fontStamp));
            cBottomCM.Colspan = 12;
            cBottomCM.HorizontalAlignment = Element.ALIGN_CENTER;
            pTable.AddCell(cBottomCM);

            pTable.AddCell(cBottom);

            PdfPCell cBottomApprover = new PdfPCell(new Phrase("APPROVER", fontStamp));
            cBottomApprover.HorizontalAlignment = Element.ALIGN_CENTER;
            cBottomApprover.Colspan = 4;
            pTable.AddCell(cBottomApprover);

            PdfPCell cBottomReviewer = new PdfPCell(new Phrase("REVIEWER", fontStamp));
            cBottomReviewer.HorizontalAlignment = Element.ALIGN_CENTER;
            cBottomReviewer.Colspan = 4;
            pTable.AddCell(cBottomReviewer);

            PdfPCell cBottomStaff = new PdfPCell(new Phrase("STAFF", fontStamp));
            cBottomStaff.HorizontalAlignment = Element.ALIGN_CENTER;
            cBottomStaff.Colspan = 4;
            pTable.AddCell(cBottomStaff);

            pTable.AddCell(cBottom);

            pTable.AddCell(chStamp);
            pTable.AddCell(chStamp);
            pTable.AddCell(chStamp);

            PdfPCell cBottomMsg = new PdfPCell(new Phrase("Kyocera Document Technology Company (H.K.) Limited   Dec, 2016", fontStamp));
            cBottomMsg.Colspan = 26;
            cBottomMsg.Border = Rectangle.NO_BORDER;
            pTable.AddCell(cBottomMsg);

            document.Add(pTable);
            document.Close();
        }

        public static void CombinePdfs(string[] filenames, string outFile)
        {
            Document document = new Document();

            PdfCopy writer = new PdfCopy(document, new FileStream(outFile, FileMode.Create));
            if (writer == null) return;

            document.Open();

            foreach (string filename in filenames)
            {
                PdfReader reader = new PdfReader(filename);
                reader.ConsolidateNamedDestinations();

                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    PdfImportedPage page = writer.GetImportedPage(reader, i);
                    writer.AddPage(page);
                }

                PRAcroForm form = reader.AcroForm;
                if (form != null)
                    writer.CopyAcroForm(reader);

                reader.Close();
            }

            writer.Close();
            document.Close();
        }
    }
}
