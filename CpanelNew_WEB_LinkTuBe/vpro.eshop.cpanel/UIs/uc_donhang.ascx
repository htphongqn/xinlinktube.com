<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_donhang.ascx.cs" Inherits="MVC_Kutun.UIs.uc_donhang" %>
<fieldset class="fld">
              <legend class="lgd"><b>Thông tin</b></legend>
              <table cellspacing="0" cellpadding="4" style=" width: 100%; border-collapse: collapse" class="tdGridTable">
                <tbody>
                  <tr style="color: #fff; background-color: #0169B0; font-size: Small; font-weight: bold;" class="cl">
                    <td></td>
                    <td> Mã ĐH </td>
                    <td> Ngày đặt hàng </td>
                    <td> Địa chỉ giao hàng </td>
                    <td> Hình thức thanh toán </td>
                    <td> Tình trạng </td>
                    <td> Tổng (đ) </td>
                  </tr>
                  <asp:Repeater ID="Re_donhang" runat="server">
                      <ItemTemplate>
                            <tr class="box_order" style="cursor: pointer">
                              <td><i class="fa fa-list-alt"></i></td>
                              <td><%# Eval("ORDER_CODE")%></td>
                              <td><%# getPublishDate(Eval("ORDER_PUBLISHDATE"))%></td>
                              <td><%# Eval("ORDER_ADDRESS")%></td>
                              <td> <%# getOrderPayment(Eval("ORDER_PAYMENT"))%></td>
                              <td><font color="red"> <%# getOrderStatus(Eval("ORDER_STATUS"))%></font></td>
                              <td><%# GetMoney(Eval("ORDER_TOTAL_AMOUNT"))%></td>
                            </tr>
                  <tr class="box_orderitem" style="display: none;">
                    <td colspan="7"><table class="mini-cart" style="margin-top:10px;">
                        <tr>
                          <td>STT<%#resetprder()%></td>
                          <td>Hình ảnh</td>
                          <td>Tên sản phẩm</td>
                          <td>Số lượng</td>
                          <td>Giá (VNĐ)</td>
                          <td>Thành tiền (VNĐ)</td>
                          <td></td>
                        </tr>
                        <asp:Repeater ID="Repeater2" runat="server" DataSource='<%#load_item(Eval("ORDER_ID"))%>'>
                              <ItemTemplate>
                                <tr>
                                  <td><%# getorder() %></td>
                                  <td><img src="<%#Get_IMG(Eval("NEWS_ID"))%>" /></td>
                                  <td><%#GET_TITLE(Eval("NEWS_ID"))%></td>
                                  <td><%# GetMoney(Eval("ITEM_PRICE"))%></td>
                                  <td><%#Eval("ITEM_QUANTITY")%></td>
                                  <td><%# GetMoney(Eval("ITEM_SUBTOTAL"))%></td>
                                  <td></td>
                                </tr>
                             </ItemTemplate>
                        </asp:Repeater>
                        <tr class="text-right">
                          <td colspan="6">Tổng tiền : <b><%# GetMoney(Eval("ORDER_TOTAL_AMOUNT"))%></b></td>
                          <td></td>
                        </tr>
                      </table></td>
                  </tr>
                  </ItemTemplate>
                  </asp:Repeater>
                </tbody>
              </table>
              <script>
                  $(function () {
                      $('.box_order').click(function () {
                          $(this).next(".box_orderitem:first").slideToggle();
                      });
                  });
</script>
            </fieldset>