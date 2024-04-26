export interface Estudiante {
    id: number;
    nombre: string;
}

export interface ResponseBase {
    codigoDeError: number;
    mensaje: string;
    response: any;
}
