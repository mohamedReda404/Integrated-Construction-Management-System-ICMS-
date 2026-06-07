import Swal from 'sweetalert2';

export class AlertService {

  static success(message: string): void {

    Swal.fire({
      icon: 'success',
      title: 'Success',
      text: message,
      timer: 2000,
      showConfirmButton: false
    });

  }

  static error(message: string): void {

    Swal.fire({
      icon: 'error',
      title: 'Error',
      text: message
    });

  }

  static warning(message: string): void {

    Swal.fire({
      icon: 'warning',
      title: 'Warning',
      text: message
    });

  }

}