$(document).ready(function () {
    $('form').submit(function (event) {
        event.preventDefault();
        var name = $('#name').val();
                $('#name').val(''); 
        $.ajax({
            type: 'POST',
            url: '/Home/GetName',
            data: { name: name },
            success: function (response) { 
                $('#output').append(LayThoiGian()); 
                $('#output').append(HamThemYOU(name)); 
                $('#output').append(HamThemAI(response)); 
                $('html, body').animate({ scrollTop: $(document).height() }, 'slow'); 
            }
        });
    });
});

function HamThemYOU(string) {
    let bien = '<div class="container-fluid"><pre>';
    bien += '<span class="right lam_mo">YOU:</span>\n';
    bien += '<span class="right">';
    bien += string;
    bien += '</span></pre></div>';
    return bien;
};
function HamThemAI(string) {
    let bien = '<div class="container-fluid"><pre>';
    bien += '<span class="left lam_mo">AI:</span>\n';
    bien += string;
    bien += '</pre></div>';
    return bien;
};
function LayThoiGian() {
    return '<div class="time">Thời gian: ' + new Date().toLocaleString() + '</div>';
}
