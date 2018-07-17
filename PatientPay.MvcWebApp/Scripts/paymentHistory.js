$("#print").on("click", function (e) {
    const pageTitle = 'Hospital Management System',
        stylesheet = '//maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css';

    const html = '<html><head><title>' + pageTitle + '</title>' +
        '<link rel="stylesheet" href="' + stylesheet + '">' +
        '</head><body>' + $('#report')[0].outerHTML + '</body></html>';

    const win = window.open('', 'print', 'width=900,height=400');
    win.document.write(html);

    win.document.close();
    win.print();
    //win.close();

    return false;
});