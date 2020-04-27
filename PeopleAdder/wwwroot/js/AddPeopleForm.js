$(() => {
    let count = 0;
    $("#add-button").on('click', () => {
        count++;
        $(`#${count-1}`).append(`<span id=${count}>
                            <div class="row">
                                <div class="col-md-3">
                                    <input name="ppl[${count}].firstName" placeholder="First Name" class="form-control" />
                                </div >
                                <div class="col-md-3">
                                    <input name="ppl[${count}].lastName" placeholder="Last Name" class="form-control" />
                                </div>
                                <div class="col-md-3">
                                    <input name="ppl[${count}].age" placeholder="Age" class="form-control" />
                                </div>
                            </div>
                        </span >`);
    });
});