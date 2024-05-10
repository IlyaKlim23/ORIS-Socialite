import {
    Toast,
    ToastContainer,
} from "react-bootstrap";


export default function ErrorToast({message}) {

    return (
        message.length > 0 &&
            <div className="col-4 h-50">
                <div className="relative errorAlert error errorToast">
                    <ToastContainer>
                        <Toast
                            bg="danger">

                            <Toast.Header>
                                <strong className="me-auto alertText">
                                    Ошибка
                                </strong>
                            </Toast.Header>

                            <Toast.Body>
                                <p className="alertText mb-4">{message}</p>
                                <div className="mt-3"></div>
                            </Toast.Body>
                        </Toast>
                    </ToastContainer>
                </div>
            </div>
    );
}