import React, { Component } from 'react';

export class DeleteOrder extends Component {
    static displayName = DeleteOrder.name;

    constructor(props) {
        super(props);
        this.state = {
            open: false
        };
    }

    deleteOrder = (id) => {
        fetch(`api/orders/${id}`,
            {
                method: 'DELETE',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                }
            })
            .then(e => {
                this.setState({ open: false })
                this.props.updateData()
            })
    }

    render() {
        return (
            <div>
                <button className="btn btn-sm btn-default" onClick={() => this.setState({ open: true })}><img src="./icons/trash.png" /></button>

                {
                    this.state.open
                        ? <div className="dialog">
                            <div className="background"></div>
                            <div className="dialog-content">
                                <div className="body">
                                    <h5>Вы действительно хотите удалить данный заказ?</h5>
                                </div>
                                <div className="footer">
                                    <button className="btn btn-danger" onClick={() => this.setState({ open: false })}>Отмена</button>
                                    <button className="btn btn-primary" onClick={() => this.deleteOrder(this.props.id)}>OK</button>
                                </div>
                            </div>
                        </div>
                        : null
                }
            </div>
        );
    }
}