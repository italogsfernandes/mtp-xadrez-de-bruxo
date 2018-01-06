
from PyQt4.QtGui import *

from PyQt4.QtCore import SIGNAL

from math import floor

CASAS = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h']
class ItaloGraphicsView(QGraphicsView):
    def mousePressEvent(self, q_mouse_event):
        #a = QMouseEvent()
        #a.
        wid = self.size().width()
        hei = self.size().height()

        distx = floor((q_mouse_event.pos().x() - wid/2)/ 45 + 4)
        disty = abs(floor((q_mouse_event.pos().y() - hei/2)/ 45 + 4) - 8)
        #print(q_mouse_event.pos())
        local = CASAS[distx] + str(disty)
        # print(local)
        self.emit(SIGNAL("clicked(QString)"), local)
        #considerando board=400px
        #square = 45px
        #beirada = 20px