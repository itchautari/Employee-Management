import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Organization } from '../../../Models/organization';

export class SharedProps {
    public form: FormGroup
    public orgInfo: Organization = new Organization();
    public language: string = 'en';
    public logoImg: string | ArrayBuffer = "";
    public logoImage: File;

    public labelEn: object = {
        orgName: "Name",
        panNo: "PAN",
        address: "Address",
        email: "Email",
        website: "Website",
        logo: "Logo",
        estd: "ESTD"
    };

    public plcHldrEn: object = {
        orgName: "Organization Name",
        panNo: "PAN Number",
        address: "Address",
        email: "Organization Email eg:example.gmail.com",
        website: "Website eg:https://www.examplesite.com",
        logo: "Logo",
        estd: "Established Date"
    };

    public labelNp: object = {
        orgName: "नाम",
        panNo: "प्यान",
        address: "यड्रेस",
        email: "ईमेल",
        website: "वेबसाईट",
        logo: "लोगो",
        estd: "समारोहा"
    }

    public plcHldrNp: object = {
        orgName: "संस्थाको नाम",
        panNo: "प्यान नंबर",
        address: "यड्रेस",
        email: "ईमेल",
        website: "वेबसाईट",
        logo: "लोगो",
        estd: "समारोह(उध्घाटन्) भयको दिन"
    }

    public _labels: object;
    public get labels(): object {
        if (this.language == 'en') {
            this._labels = this.labelEn
        } else {
            this._labels = this.labelNp
        }
        return this._labels;
    }

    public _plcHldr: object;
    public get plcHldr(): object {
        if (this.language == 'en') {
            this._plcHldr = this.plcHldrEn;
        } else {
            this._plcHldr = this.plcHldrNp;
        }
        return this._plcHldr;
    }

    // public fb: FormBuilder;

    constructor(private fb: FormBuilder){}

    public createform(model: Organization): FormGroup {
        return this.fb.group({
            organizationId: [model.organizationId],
            organizationNameEn: [model.organizationNameEn, Validators.required],
            organizationNameNp: [model.organizationNameNp],
            panNo: [model.panNo],
            addressEn: [model.addressEn, Validators.required],
            addressNp: [model.addressNp],
            email: [model.email, Validators.compose([Validators.required])],
            website: [model.website],
            logo: [model.logo],
            establishedDateEn: [model.establishedDateEn, Validators.required],
            establishedDateNp: [model.establishedDateNp],
            createDateEn: [model.createDateEn, Validators.required],
            createDateNp: [model.createDateNp],
            modifiedDate: [model.modifiedDate, Validators.required],
            modifiedBy: [model.modifiedBy, Validators.required]
        });
    }

    public popupFileChooser() {
        document.getElementById("fiLogo").click();
    }

    public fileChanged(event) {
        if (event.target.files.length == 0) {
            this.logoImg = ""
            return;
        }
        
        this.logoImage = event.target.files[0];

        var reader = new FileReader();
        reader.readAsDataURL(this.logoImage);
        reader.onload = (_event) => {
            this.logoImg = reader.result;
        }

    }
}
