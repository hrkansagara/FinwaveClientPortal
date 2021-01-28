! function (o) {
	"use strict";

	function e() {
		this.$body = o("body"), this.charts = []
	}
	e.prototype.initCharts = function () {
		window.Apex = {
			chart: {
				parentHeightOffset: 0,
				toolbar: {
					show: !1
				}
			},
			grid: {
				padding: {
					left: 0,
					right: 0
				}
			},
			colors: ["#727cf5", "#0acf97", "#fa5c7c", "#ffbc00"]
		};
		var e = ["#727cf5", "#0acf97", "#fa5c7c", "#ffbc00"],
			t = o("#revenue-chart").data("colors");
		t && (e = t.split(","));
		var r = {
			chart: {
				height: 364,
				type: "line",
				dropShadow: {
					enabled: !0,
					opacity: .2,
					blur: 7,
					left: -7,
					top: 7
				}
			},
			dataLabels: {
				enabled: !1
			},
			stroke: {
				curve: "smooth",
				width: 4
			},
			series: [{
				name: "Current Week",
				data: [10, 20, 15, 25, 20, 30, 20]
			}, {
				name: "Previous Week",
				data: [0, 15, 10, 30, 15, 35, 25]
			}],
			colors: e,
			zoom: {
				enabled: !1
			},
			legend: {
				show: !1
			},
			xaxis: {
				type: "string",
				categories: ["Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"],
				tooltip: {
					enabled: !1
				},
				axisBorder: {
					show: !1
				}
			},
			yaxis: {
				labels: {
					formatter: function (e) {
						return e + "k"
					},
					offsetX: -15
				}
			}
		};


		// Assets Current
		new ApexCharts(document.querySelector("#high-performing-product"), r).render();
		e = ["#727cf5", "#0acf97", "#fa5c7c", "#ffbc00"];
		(t = o("#average-sales").data("colors")) && (e = t.split(","));
		r = {
			chart: {
				height: 213,
				type: "donut"
			},
			legend: {
				show: !1
			},
			stroke: {
				colors: ["transparent"]
			},
			series: [70, 15, 15],
			labels: ["Financial", "Industrial", "Energy"],
			colors: e,
			responsive: [{
				breakpoint: 480,
				options: {
					chart: {
						width: 200
					},
					legend: {
						position: "bottom"
					}
				}
			}]
		};
		new ApexCharts(document.querySelector("#average-sales"), r).render()


		new ApexCharts(document.querySelector("#high-performing-product"), r).render();
		e = ["#727cf5", "#0acf97", "#fa5c7c", "#ffbc00"];
		(t = o("#average-sales1").data("colors")) && (e = t.split(","));
		r = {
			chart: {
				height: 213,
				type: "donut"
			},
			legend: {
				show: !1
			},
			stroke: {
				colors: ["transparent"]
			},
			series: [100],
			labels: ["Equity"],
			colors: e,
			responsive: [{
				breakpoint: 480,
				options: {
					chart: {
						width: 200
					},
					legend: {
						position: "bottom"
					}
				}
			}]
		};
		new ApexCharts(document.querySelector("#average-sales1"), r).render()

		new ApexCharts(document.querySelector("#high-performing-product"), r).render();
		e = ["#727cf5", "#0acf97", "#fa5c7c", "#ffbc00"];
		(t = o("#average-sales2").data("colors")) && (e = t.split(","));
		r = {
			chart: {
				height: 213,
				type: "donut"
			},
			legend: {
				show: !1
			},
			stroke: {
				colors: ["transparent"]
			},
			series: [30,30,20,20],
			labels: ["Equity"],
			colors: e,
			responsive: [{
				breakpoint: 480,
				options: {
					chart: {
						width: 200
					},
					legend: {
						position: "bottom"
					}
				}
			}]
		};
		new ApexCharts(document.querySelector("#average-sales2"), r).render()


		// Assets Invested
		new ApexCharts(document.querySelector("#high-performing-product"), r).render();
		e = ["#727cf5", "#0acf97", "#fa5c7c", "#ffbc00"];
		(t = o("#average-sales3").data("colors")) && (e = t.split(","));
		r = {
			chart: {
				height: 213,
				type: "donut"
			},
			legend: {
				show: !1
			},
			stroke: {
				colors: ["transparent"]
			},
			series: [70, 15, 15],
			labels: ["Financial", "Industrial", "Energy"],
			colors: e,
			responsive: [{
				breakpoint: 480,
				options: {
					chart: {
						width: 200
					},
					legend: {
						position: "bottom"
					}
				}
			}]
		};
		new ApexCharts(document.querySelector("#average-sales3"), r).render()


		new ApexCharts(document.querySelector("#high-performing-product"), r).render();
		e = ["#727cf5", "#0acf97", "#fa5c7c", "#ffbc00"];
		(t = o("#average-sales4").data("colors")) && (e = t.split(","));
		r = {
			chart: {
				height: 213,
				type: "donut"
			},
			legend: {
				show: !1
			},
			stroke: {
				colors: ["transparent"]
			},
			series: [100],
			labels: ["Equity"],
			colors: e,
			responsive: [{
				breakpoint: 480,
				options: {
					chart: {
						width: 200
					},
					legend: {
						position: "bottom"
					}
				}
			}]
		};
		new ApexCharts(document.querySelector("#average-sales4"), r).render()

		new ApexCharts(document.querySelector("#high-performing-product"), r).render();
		e = ["#727cf5", "#0acf97", "#fa5c7c", "#ffbc00"];
		(t = o("#average-sales5").data("colors")) && (e = t.split(","));
		r = {
			chart: {
				height: 213,
				type: "donut"
			},
			legend: {
				show: !1
			},
			stroke: {
				colors: ["transparent"]
			},
			series: [30,30,20,20],
			labels: ["Equity"],
			colors: e,
			responsive: [{
				breakpoint: 480,
				options: {
					chart: {
						width: 200
					},
					legend: {
						position: "bottom"
					}
				}
			}]
		};
		new ApexCharts(document.querySelector("#average-sales5"), r).render()


		// Sector Current
		new ApexCharts(document.querySelector("#high-performing-product"), r).render();
		e = ["#727cf5", "#0acf97", "#fa5c7c", "#ffbc00"];
		(t = o("#average-sales6").data("colors")) && (e = t.split(","));
		r = {
			chart: {
				height: 213,
				type: "donut"
			},
			legend: {
				show: !1
			},
			stroke: {
				colors: ["transparent"]
			},
			series: [70, 15, 15],
			labels: ["Financial", "Industrial", "Energy"],
			colors: e,
			responsive: [{
				breakpoint: 480,
				options: {
					chart: {
						width: 200
					},
					legend: {
						position: "bottom"
					}
				}
			}]
		};
		new ApexCharts(document.querySelector("#average-sales6"), r).render()


		new ApexCharts(document.querySelector("#high-performing-product"), r).render();
		e = ["#727cf5", "#0acf97", "#fa5c7c", "#ffbc00"];
		(t = o("#average-sales7").data("colors")) && (e = t.split(","));
		r = {
			chart: {
				height: 213,
				type: "donut"
			},
			legend: {
				show: !1
			},
			stroke: {
				colors: ["transparent"]
			},
			series: [100],
			labels: ["Equity"],
			colors: e,
			responsive: [{
				breakpoint: 480,
				options: {
					chart: {
						width: 200
					},
					legend: {
						position: "bottom"
					}
				}
			}]
		};
		new ApexCharts(document.querySelector("#average-sales7"), r).render()

		new ApexCharts(document.querySelector("#high-performing-product"), r).render();
		e = ["#727cf5", "#0acf97", "#fa5c7c", "#ffbc00"];
		(t = o("#average-sales8").data("colors")) && (e = t.split(","));
		r = {
			chart: {
				height: 213,
				type: "donut"
			},
			legend: {
				show: !1
			},
			stroke: {
				colors: ["transparent"]
			},
			series: [30,30,20,20],
			labels: ["Equity"],
			colors: e,
			responsive: [{
				breakpoint: 480,
				options: {
					chart: {
						width: 200
					},
					legend: {
						position: "bottom"
					}
				}
			}]
		};
		new ApexCharts(document.querySelector("#average-sales8"), r).render()


		// Sector Invested
		new ApexCharts(document.querySelector("#high-performing-product"), r).render();
		e = ["#727cf5", "#0acf97", "#fa5c7c", "#ffbc00"];
		(t = o("#average-sales9").data("colors")) && (e = t.split(","));
		r = {
			chart: {
				height: 213,
				type: "donut"
			},
			legend: {
				show: !1
			},
			stroke: {
				colors: ["transparent"]
			},
			series: [70, 15, 15],
			labels: ["Financial", "Industrial", "Energy"],
			colors: e,
			responsive: [{
				breakpoint: 480,
				options: {
					chart: {
						width: 200
					},
					legend: {
						position: "bottom"
					}
				}
			}]
		};
		new ApexCharts(document.querySelector("#average-sales9"), r).render()


		new ApexCharts(document.querySelector("#high-performing-product"), r).render();
		e = ["#727cf5", "#0acf97", "#fa5c7c", "#ffbc00"];
		(t = o("#average-sales10").data("colors")) && (e = t.split(","));
		r = {
			chart: {
				height: 213,
				type: "donut"
			},
			legend: {
				show: !1
			},
			stroke: {
				colors: ["transparent"]
			},
			series: [100],
			labels: ["Equity"],
			colors: e,
			responsive: [{
				breakpoint: 480,
				options: {
					chart: {
						width: 200
					},
					legend: {
						position: "bottom"
					}
				}
			}]
		};
		new ApexCharts(document.querySelector("#average-sales10"), r).render()

		new ApexCharts(document.querySelector("#high-performing-product"), r).render();
		e = ["#727cf5", "#0acf97", "#fa5c7c", "#ffbc00"];
		(t = o("#average-sales11").data("colors")) && (e = t.split(","));
		r = {
			chart: {
				height: 213,
				type: "donut"
			},
			legend: {
				show: !1
			},
			stroke: {
				colors: ["transparent"]
			},
			series: [30,30,20,20],
			labels: ["Equity"],
			colors: e,
			responsive: [{
				breakpoint: 480,
				options: {
					chart: {
						width: 200
					},
					legend: {
						position: "bottom"
					}
				}
			}]
		};
		new ApexCharts(document.querySelector("#average-sales11"), r).render()


		// Sector Current
		new ApexCharts(document.querySelector("#high-performing-product"), r).render();
		e = ["#727cf5", "#0acf97", "#fa5c7c", "#ffbc00"];
		(t = o("#average-sales12").data("colors")) && (e = t.split(","));
		r = {
			chart: {
				height: 213,
				type: "donut"
			},
			legend: {
				show: !1
			},
			stroke: {
				colors: ["transparent"]
			},
			series: [70, 15, 15],
			labels: ["Financial", "Industrial", "Energy"],
			colors: e,
			responsive: [{
				breakpoint: 480,
				options: {
					chart: {
						width: 200
					},
					legend: {
						position: "bottom"
					}
				}
			}]
		};
		new ApexCharts(document.querySelector("#average-sales12"), r).render()


		new ApexCharts(document.querySelector("#high-performing-product"), r).render();
		e = ["#727cf5", "#0acf97", "#fa5c7c", "#ffbc00"];
		(t = o("#average-sales13").data("colors")) && (e = t.split(","));
		r = {
			chart: {
				height: 213,
				type: "donut"
			},
			legend: {
				show: !1
			},
			stroke: {
				colors: ["transparent"]
			},
			series: [100],
			labels: ["Equity"],
			colors: e,
			responsive: [{
				breakpoint: 480,
				options: {
					chart: {
						width: 200
					},
					legend: {
						position: "bottom"
					}
				}
			}]
		};
		new ApexCharts(document.querySelector("#average-sales13"), r).render()

		new ApexCharts(document.querySelector("#high-performing-product"), r).render();
		e = ["#727cf5", "#0acf97", "#fa5c7c", "#ffbc00"];
		(t = o("#average-sales14").data("colors")) && (e = t.split(","));
		r = {
			chart: {
				height: 213,
				type: "donut"
			},
			legend: {
				show: !1
			},
			stroke: {
				colors: ["transparent"]
			},
			series: [30,30,20,20],
			labels: ["Equity"],
			colors: e,
			responsive: [{
				breakpoint: 480,
				options: {
					chart: {
						width: 200
					},
					legend: {
						position: "bottom"
					}
				}
			}]
		};
		new ApexCharts(document.querySelector("#average-sales14"), r).render()


		// Sector Invested
		new ApexCharts(document.querySelector("#high-performing-product"), r).render();
		e = ["#727cf5", "#0acf97", "#fa5c7c", "#ffbc00"];
		(t = o("#average-sales15").data("colors")) && (e = t.split(","));
		r = {
			chart: {
				height: 213,
				type: "donut"
			},
			legend: {
				show: !1
			},
			stroke: {
				colors: ["transparent"]
			},
			series: [70, 15, 15],
			labels: ["Financial", "Industrial", "Energy"],
			colors: e,
			responsive: [{
				breakpoint: 480,
				options: {
					chart: {
						width: 200
					},
					legend: {
						position: "bottom"
					}
				}
			}]
		};
		new ApexCharts(document.querySelector("#average-sales15"), r).render()


		new ApexCharts(document.querySelector("#high-performing-product"), r).render();
		e = ["#727cf5", "#0acf97", "#fa5c7c", "#ffbc00"];
		(t = o("#average-sales16").data("colors")) && (e = t.split(","));
		r = {
			chart: {
				height: 213,
				type: "donut"
			},
			legend: {
				show: !1
			},
			stroke: {
				colors: ["transparent"]
			},
			series: [100],
			labels: ["Equity"],
			colors: e,
			responsive: [{
				breakpoint: 480,
				options: {
					chart: {
						width: 200
					},
					legend: {
						position: "bottom"
					}
				}
			}]
		};
		new ApexCharts(document.querySelector("#average-sales16"), r).render()

		new ApexCharts(document.querySelector("#high-performing-product"), r).render();
		e = ["#727cf5", "#0acf97", "#fa5c7c", "#ffbc00"];
		(t = o("#average-sales17").data("colors")) && (e = t.split(","));
		r = {
			chart: {
				height: 213,
				type: "donut"
			},
			legend: {
				show: !1
			},
			stroke: {
				colors: ["transparent"]
			},
			series: [30,30,20,20],
			labels: ["Equity"],
			colors: e,
			responsive: [{
				breakpoint: 480,
				options: {
					chart: {
						width: 200
					},
					legend: {
						position: "bottom"
					}
				}
			}]
		};
		new ApexCharts(document.querySelector("#average-sales17"), r).render()

		
	}, e.prototype.init = function () {
		o("#dash-daterange").daterangepicker({
			singleDatePicker: !0
		}), this.initCharts(), this.initMaps()
	}, o.Dashboard = new e, o.Dashboard.Constructor = e
}(window.jQuery),
function (t) {
	"use strict";
	t(document).ready(function (e) {
		t.Dashboard.init()
	})
}(window.jQuery);