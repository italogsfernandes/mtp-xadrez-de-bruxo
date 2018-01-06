# -*- coding: utf-8 -*-
# ------------------------------------------------------------------------------
# FEDERAL UNIVERSITY OF UBERLANDIA
# Faculty of Electrical Engineering
# Biomedical Engineering Lab
# ------------------------------------------------------------------------------
# Author: Italo Gustavo Sampaio Fernandes
# Contact: italogsfernandes@gmail.com
# Git: www.github.com/italogfernandes
# ------------------------------------------------------------------------------
# Decription:
# ------------------------------------------------------------------------------
# from PyQt5.QtWidgets import *
from PyQt4.QtGui import *

from PyQt4 import QtSvg
from PyQt4.QtCore import SIGNAL

import sys
from views import base

import chess
import chess.svg
import chess.uci

from controllers import myqgraph
class ExampleApp(QMainWindow, base.Ui_MainWindow):
    def __init__(self, parent=None):
        super(self.__class__, self).__init__(parent)
        self.setupUi(self)

        self.graphicsViewBoard = myqgraph.ItaloGraphicsView(self.centralwidget)
        self.graphicsViewBoard.setObjectName(("graphicsViewBoard"))
        self.verticalLayout_7.removeWidget(self.label_3)
        self.label_3.setParent(None)
        self.verticalLayout_7.addWidget(self.graphicsViewBoard)

        self.engine = chess.uci.popen_engine("models/stockfish-8-linux/Linux/stockfish_8_x64")
        self.engine.uci()

        self.board = chess.Board()
        self.board_svg = chess.svg.board(self.board)
        self.scene = QGraphicsScene(self.graphicsViewBoard)
        self.graphicsViewBoard.setScene(self.scene)
        self.item = QtSvg.QGraphicsSvgItem('tmp.svg')

        self.btnOpIniciar.clicked.connect(self.do_iniciar)
        self.comboBoxMoveFrom.currentIndexChanged.connect(self.populate_move_to)
        self.pushButtonMove.clicked.connect(self.btn_move_clicked)
        self.btn_computer_move.clicked.connect(self.do_computer_move)
        self.checkBoxUciSan.stateChanged.connect(self.uci_san_changed)

        self.connect(self.graphicsViewBoard, SIGNAL("clicked(QString)"), self.board_clicked)
        self.command = None

        self.btn_computer_move.setVisible(False)
        self.do_iniciar()

        self.start_in = None
        self.finish_in = None

    def board_clicked(self, square):
        if self.start_in is None:
            self.start_in = square
        else:
            self.finish_in = square
            self.move_uci(self.start_in + self.finish_in)
            self.start_in = None

    def uci_san_changed(self):
        if self.checkBoxUciSan.checkState():
            self.label_2.setText("Piece:")
        else:
            self.label_2.setText("From:")

        self.populate_move_from()


    def computer_callback(self, command):
        bestmove, ponder = self.command.result()
        if self.command.done():
            self.move_uci(str(bestmove))

    def do_computer_move(self):
        self.engine.position(self.board)
        bestmove, ponder = self.engine.go(movetime=250)
        self.move_uci(str(bestmove))
        #self.command = self.engine.go(movetime=2000, async_callback=self.computer_callback)
        #print(bestmove)
        #best_move = self.engine.go(movetime=2000)  # Gets a tuple of bestmove and ponder move


    def move_uci(self, move):
        self.board.push_uci(move)
        self.update_board()
        self.populate_move_from()
        if self.board.is_checkmate():
            self.pushButtonMove.setEnabled(False)

    def move_from_to(self, from_square, to_square):
        self.move_uci(from_square + to_square)

    def do_iniciar(self):
        if self.checkBoxComputer.checkState():
            pass
        self.board.reset()
        self.update_board()
        self.populate_move_from()

    def btn_move_clicked(self):
        self.move_from_to(self.comboBoxMoveFrom.currentText().lower(), self.comboBoxMoveTo.currentText().lower())
        if self.checkBoxComputer.checkState():
            self.do_computer_move()


    def iniciar_jogo(self):
        self.board = chess.Board()
        self.popular_menu_mover()

    def populate_move_from(self):
        self.comboBoxMoveFrom.clear()

        a = str(self.board.legal_moves)
        b = a[a.index('(') + 1:a.index(')')].split(', ')

        l = []
        if self.checkBoxUciSan.checkState():
            for move in b:
                move_piece = move[0] if len(move) > 2 else 'P'
                #move_piece = chess.PIECE_NAMES[chess.PIECE_SYMBOLS.index(move_piece.lower())]
                if move_piece not in l:
                    l.append(move_piece)
                    self.comboBoxMoveFrom.addItem(move_piece)

        else:
            for move in self.board.legal_moves:
                move_from = chess.square_name(move.from_square).upper()
                if move_from not in l:
                    l.append(move_from)
                    self.comboBoxMoveFrom.addItem(move_from)

        if len(l) > 0:
            self.comboBoxMoveFrom.setCurrentIndex(0)

        self.populate_move_to()

    def populate_move_to(self):
        self.comboBoxMoveTo.clear()

        a = str(self.board.legal_moves)
        b = a[a.index('(') + 1:a.index(')')].split(', ')

        if len(self.comboBoxMoveFrom.currentText()) and self.checkBoxUciSan.checkState():
            for move in b:
                if len(move) <= 2 and (self.comboBoxMoveFrom.currentText().startswith('P')):
                    self.comboBoxMoveTo.addItem(move)
                elif move.startswith(self.comboBoxMoveFrom.currentText()[0]):
                    self.comboBoxMoveTo.addItem(move[1::])

        else:
            for move in self.board.legal_moves:
                move_from = chess.square_name(move.from_square).upper()
                move_to = chess.square_name(move.to_square).upper()
                if move_from == self.comboBoxMoveFrom.currentText():
                    self.comboBoxMoveTo.addItem(move_to)

    def update_board(self):
        self.board_svg = chess.svg.board(self.board, size=400)
        with open('tmp.svg', 'w') as temp_file:
            temp_file.write(self.board_svg)

        if len(self.scene.items()) > 0:
            self.scene.removeItem(self.scene.items()[0])
        self.item = QtSvg.QGraphicsSvgItem('tmp.svg')
        self.scene.addItem(self.item)


def main():
    app = QApplication(sys.argv)
    form = ExampleApp()
    form.show()
    app.exec_()

if __name__ == "__main__":
    main()
