public enum SVGPathSegTypes : ushort {
  Unknown       = 0,
  Close       = 1,
  MoveTo_Abs       = 2,
  MoveTo_Rel       = 3,
  LineTo_Abs       = 4,
  LineTo_Rel       = 5,
  CurveTo_Cubic_Abs     = 6,
  CurveTo_Cubic_Rel     = 7,
  CurveTo_Quadratic_Abs     = 8,
  CurveTo_Quadratic_Rel     = 9,
  Arc_Abs       = 10,
  Arc_Rel       = 11,
  LineTo_Horizontal_Abs     = 12,
  LineTo_Horizontal_Rel     = 13,
  LineTo_Vertical_Abs     = 14,
  LineTo_Vertical_Rel     = 15,
  CurveTo_Cubic_Smooth_Abs   = 16,
  CurveTo_Cubic_Smooth_Rel   = 17,
  CurveTo_Quadratic_Smooth_Abs   = 18,
  CurveTo_Quadratic_Smooth_Rel   = 19
}
/*************************************************************************************************/
public abstract class SVGPathSeg {
  protected SVGPathSegList _segList;
  protected int _segIndex;
  /***********************************************************************************/
  /***********************************************************************************/
  internal void SetList(SVGPathSegList segList) {
    this._segList = segList;
  }
  internal void SetIndex(int segIndex) {
    this._segIndex = segIndex;
  }
  public SVGPathSeg previousSeg {
    get {
      return _segList.GetPreviousSegment(this);
    }
  }
  /***********************************************************************************/
  public abstract SVGPoint currentPoint{get;}
  public SVGPoint previousPoint {
    get {
      SVGPoint _return = new SVGPoint(0f,0f);
      SVGPathSeg _prevSeg = previousSeg;
      if(_prevSeg != null) {
        _return.x = _prevSeg.currentPoint.x;
        _return.y = _prevSeg.currentPoint.y;
      }
      return _return;
    }
  }
}