export interface Profesor {
    id: number;
    nombre: string;
}

export interface ResponseBaseProfesor {
    codigoDeError: number;
    mensaje: string;
    response: any;
}
