; (function ($) {
	'use strict';
	$.fn.serializeJSON = function () {
		var json = {};
		$.each(this.find('input,select,textarea'), function (i) {
			var el = $(this),
              key = el.attr('name'),
              val = el.val();

			//if (val != '' && val !== undefined && val !== null) {
			if (val !== undefined && val !== null) {
				if (el.is(':checkbox')) {
					el.prop('checked') && ($.isArray(json[key]) ? json[key].push(val) : json[key] = [val]);
				} else if (el.is(':radio')) {
					el.prop('checked') && (json[key] = val);
				} else if (el.is('select')) {
					json[key] = el.val();
				} else if (el.is('input[type="reset"]') || el.is(':button')) {

				} else {
					json[key] = val;
				}
			}
		});

		return json;
	};
})(jQuery);