<%@ Page Title="" Language="C#" MasterPageFile="~/headerfooter.master" AutoEventWireup="true" CodeFile="Cause.aspx.cs" Inherits="Cause" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<form runat="server">
<div class="banner-item" style="background-image:url('<%=img %>'); background-repeat:no-repeat; background-size:cover;">
    <div class="banner-content">
        <div class="container">
            <div class="row align-items-center">
                <div class="col-lg-7">
                    <h1 class="banner-title"><%=title %></h1>
                    <p class="banner-subtext"><%=description %></p>
                    <div class="button-group">
                        <a class="btn btn-lg" href="Donate.aspx?cause=<%=id.ToString() %>">Faire un don</a>
                        <br />
                        <br />
                        <asp:Button ID="acpt" runat="server" class="btn btn-lg" Text="Accepter" OnClick="acpt_Click" CausesValidation="False" />
                        <br />
                        <br />
                        <asp:Button ID="sprm" runat="server" class="btn btn-lg" Text="Supprimer" OnClick="Unnamed2_Click" />
                    </div>
                </div>
                <div class="col-lg-5">
                    <div class="banner-donation-state">
                        <div class="progress-rounded">
                            <div class="progress-value"><%=((raised*100)/goal).ToString("F0") %>%<span>Amassé</span></div>
                            <svg><circle class="progress-cicle" cx="117" cy="117" r="106" stroke-width="20" fill="none" aria-orientation="vertical" aria-valuemin="0" aria-valuemax="l00" aria-valuenow="<%=(raised*100)/goal %>"/></svg>
                        </div>
                        <h5>Faire a don</h5>
                        <p>Là où il y a de la charité et de la sagesse, il n'y a ni peur ni ignorance.</p>
                        <a class="btn btn-lg btn-border btn-white" href="#cause-dts">Details</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="main-wrap">

<!-- Causes -->
<div id="cause-dts" class="section section-padding causes-section">
	<div class="container">
		<div class="row">
			<div class="col-lg-8">
				<div class="causes cause-single">
					<div class="cause">
						<p><b><%=description %></b></p>
						<p><%=body %></p>
                    </div>
					<!-- Share on social -->
					<div class="share-on">
						
					</div>
					<!-- Recent Donation -->
					<div runat="server" id="donss" class="cause-donation">
						<h5 class="donation-title">Dons</h5>
					</div>
				</div>
			</div>
			<div class="col-lg-4">
				<aside class="sidebar widget-area">
					<!-- Fund Raising States Widget -->
					<div class="widget widget_funds">
						<div class="fund-states-wrap">
							<div class="progress-rounded fund-raises-progress">
								<div class="progress-value"><%=((raised*100)/goal).ToString("F0") %>%</div>
								<svg><circle class="progress-cicle small" cx="40" cy="40" r="35" stroke-width="8" fill="none" role="slider" aria-orientation="vertical" aria-valuemin="0" aria-valuemax="100" aria-valuenow="<%=((raised*100)/goal).ToString("F0") %>" style="stroke-dashoffset: 55px;"></circle></svg>
							</div>
							<div class="text-state">
								<p class="raised-fund"><%=raised.ToString("F2") %>DH Raised</p>
								<p class="goal-fund"><%=goal.ToString("F2") %>DH Goal</p>
								<h5 class="needed-fund"><%=goal-raised %>DH Needed</h5>
								<div class="countdown countdown-widget" data-time="12/12/2019 12:00:00 AM"><span class="section_count"><span class="section_count_data"><span class="count-data"><span class="tcount days">223 </span><span class="text">Days</span></span><svg><circle cx="35" cy="35" r="32" stroke-width="6" fill="none" stroke-dashoffset="78.22138082191782"></circle></svg></span></span><span class="section_count"><span class="section_count_data"><span class="count-data"><span class="tcount hours">07</span><span class="text">Hours</span></span><svg><circle cx="35" cy="35" r="32" stroke-width="6" fill="none" stroke-dashoffset="142.4189166666667"></circle></svg></span></span><span class="section_count"><span class="section_count_data"><span class="count-data"><span class="tcount minutes">47</span><span class="text">Min</span></span><svg><circle cx="35" cy="35" r="32" stroke-width="6" fill="none" stroke-dashoffset="43.563433333333336"></circle></svg></span></span><span class="section_count"><span class="section_count_data"><span class="count-data"><span class="tcount seconds">44</span><span class="text">Sec</span></span><svg><circle cx="35" cy="35" r="32" stroke-width="6" fill="none" stroke-dashoffset="53.61653333333334"></circle></svg></span></span></div>
							</div>
							<a class="btn btn-sm" href="Donate.aspx?cause=<%=id.ToString() %>">Faire un don</a>
						</div>
					</div>
					
				</aside>
			</div>
		</div>
	</div>
</div>
<!-- Causes End -->
</div>
</form>
</asp:Content>

