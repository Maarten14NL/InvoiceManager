import { Injectable } from '@angular/core';
import { ToasterConfig } from 'angular2-toaster';

// import 'style-loader!angular2-toaster/toaster.css';
import {
    NbComponentStatus,
    NbGlobalLogicalPosition,
    NbGlobalPhysicalPosition,
    NbGlobalPosition,
    NbToastrService,
} from '@nebular/theme';

@Injectable()
export class AlertService {
    constructor(private toastrService: NbToastrService) { }

    config: ToasterConfig;

    index = 1;
    destroyByClick = true;
    duration = 5000;
    hasIcon = true;
    position: NbGlobalPosition = NbGlobalPhysicalPosition.TOP_RIGHT;
    preventDuplicates = false;
    status: NbComponentStatus = 'primary';

    types: NbComponentStatus[] = [
        'primary',
        'success',
        'info',
        'warning',
        'danger',
    ];
    positions: string[] = [
        NbGlobalPhysicalPosition.TOP_RIGHT,
        NbGlobalPhysicalPosition.TOP_LEFT,
        NbGlobalPhysicalPosition.BOTTOM_LEFT,
        NbGlobalPhysicalPosition.BOTTOM_RIGHT,
        NbGlobalLogicalPosition.TOP_END,
        NbGlobalLogicalPosition.TOP_START,
        NbGlobalLogicalPosition.BOTTOM_END,
        NbGlobalLogicalPosition.BOTTOM_START,
    ];

    Error = function (description) {
        this.showToast('danger', 'Error', description);
    }

    Success = function (description) {
        this.showToast('success', 'Success', description);
    }

    Info = function (description) {
        this.showToast('info', 'Info', description);
    }

    Warning = function (description) {
        this.showToast('warning', 'Warning', description);
    }

    Primary = function (description) {
        this.showToast('primary', 'Primary', description);
    }

    private showToast(type: NbComponentStatus, title: string, body: string) {
        const config = {
            status: type,
            destroyByClick: this.destroyByClick,
            duration: this.duration,
            hasIcon: this.hasIcon,
            position: this.position,
            preventDuplicates: this.preventDuplicates,
        };
        const titleContent = title ? title : '';

        this.index += 1;
        this.toastrService.show(
            body,
            titleContent,
            config);
    }
}