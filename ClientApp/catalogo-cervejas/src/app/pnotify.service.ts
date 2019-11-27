import { Injectable } from '@angular/core';
import PNotify from 'pnotify/dist/es/PNotify';
import PNotifyButtons from 'pnotify/dist/es/PNotifyButtons';

@Injectable()
export class PnotifyService {

    getPNotify() {
        PNotifyButtons;
        PNotify.defaults.icons = 'fontawesome5';
        PNotify.defaults.styling = 'bootstrap4';
        return PNotify;
    }
}
