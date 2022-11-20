import React, { Component } from 'react';

export class DeleteOrderItem extends Component {
    static displayName = DeleteOrderItem.name;

    constructor(props) {
        super(props);
        this.state = {
            open: false
        };
    }

    deleteOrderItem = (id) => {
        fetch(`api/orders/deleteOrderItem/${id}`,
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
                                    <h5>Вы действительно хотите удалить данный элемент заказа?</h5>
                                </div>
                                <div className="footer">
                                    <button className="btn btn-danger" onClick={() => this.setState({ open: false })}>Отмена</button>
                                    <button className="btn btn-primary" onClick={() => this.deleteOrderItem(this.props.id)}>OK</button>
                                </div>
                            </div>
                        </div>
                        : null
                }
            </div>
        );
    }
}